using Accord.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ScreenRecorder
{
    internal class ScreenRecorder
    {
        //Video variables:
        private Rectangle bounds;
        private string outputPath = "";
        private string tempPath = "";
        private int fileCount = 1;
        private List<string> inputImageSequence = new List<string>();

        //File variables:
        private string audioName = "mic.wav";
        private string videoName = "video.mp4";
        private static string finalName;

        //Time variables:
        Stopwatch watch = new Stopwatch();

        //Audio variables:
        public static class NativeMethods
        {
            [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            public static extern int Recording(string ipstrCommand, string ipstrReturnString, int uReturnLength, int hwndCallback);
        }

        public ScreenRecorder(Rectangle b)
        {
            CreateTempFolder("tempScreenShots");

            bounds = b;
        }

        public bool SelectFolder()
        {
            using (StreamReader sr = new StreamReader(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
            {
                outputPath = sr.ReadLine();
            }

            return outputPath != null;
        }

        private void CreateTempFolder(string name)
        {
            if (Directory.Exists("D://"))
            {
                string pathName = $"D://{name}";
                Directory.CreateDirectory(pathName);
                tempPath = pathName;
            }
            else
            {
                string pathName = $"C://{name}";
                Directory.CreateDirectory(pathName);
                tempPath = pathName;
            }
        }
        private void DeletePath(string targetDir)
        {
            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeletePath(dir);
            }

            Directory.Delete(targetDir, false);
        }

        private void DeleteFilesExcetp(string targetFile)
        {
            string[] files = Directory.GetFiles(targetFile);

            foreach (string file in files)
                if (!file.Contains("Final"))
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
        }

        public void CleanUp()
        {
            if (Directory.Exists(tempPath))
            {
                DeletePath(tempPath);
            }
        }

        public string GetElapsed()
        {
            return String.Format("{0:d2}:{1:D2}:{2:D2}", watch.Elapsed.Hours, watch.Elapsed.Minutes, watch.Elapsed.Seconds);
        }

        public void RecordVideo()
        {
            watch.Start();

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                string name = tempPath + "//screenshot-" + fileCount + ".png";
                bitmap.Save(name, ImageFormat.Png);
                inputImageSequence.Add(name);
                fileCount++;

                bitmap.Dispose();
            }
        }

        public void RecordAudio()
        {
            NativeMethods.Recording("open new Type waveaudio Alias recsound", "", 0, 0);
            NativeMethods.Recording("record recsound", "", 0, 0);
        }

        private void SaveVideo(int width, int heigth, int frameRate, int bitRate)
        {
            using (StreamReader sr = new StreamReader(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
            {
                outputPath = sr.ReadLine();
            }

            using (VideoFileWriter vFWriter = new VideoFileWriter())
            {
                vFWriter.Open(outputPath + "//" + videoName, width, heigth, frameRate, VideoCodec.MPEG4, bitRate);

                foreach (string imageLoc in inputImageSequence)
                {
                    Bitmap imageFrame = Image.FromFile(imageLoc) as Bitmap;
                    vFWriter.WriteVideoFrame(imageFrame);
                    imageFrame.Dispose();
                }

                vFWriter.Close();
            }
        }

        private void SaveAudio()
        {
            using (StreamReader sr = new StreamReader(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
            {
                outputPath = sr.ReadLine();
            }

            string audioPath = "save recsound " + outputPath + "//" + audioName;
            NativeMethods.Recording(audioPath, "", 0, 0);
            NativeMethods.Recording("close recsound", "", 0, 0);
        }

        private void CombineVideoAndAudio(string video, string audio)
        {
            finalName = "FinalVideo" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + ".mp4";

            using (StreamReader sr = new StreamReader(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
            {
                outputPath = sr.ReadLine();
            }

            string command = $"/c ffmpeg -i \"{video}\" -i \"{audio}\" -shortest {finalName}";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                WorkingDirectory = outputPath,
                Arguments = command
            };

            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }

        public void Stop()
        {
            watch.Stop();

            int width = bounds.Width;
            int height = bounds.Height;
            int frameRate = 15;
            int bitRate = 100000000;

            SaveAudio();

            SaveVideo(width, height, frameRate, bitRate);

            CombineVideoAndAudio(videoName, audioName);

            DeletePath(tempPath);

            DeleteFilesExcetp(outputPath);
        }
    }
}
