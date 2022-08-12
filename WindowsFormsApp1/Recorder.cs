using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenRecorder
{
    public partial class Recorder : Form
    {
        ScreenRecorder screenRecorder = new ScreenRecorder(new Rectangle());

        public Recorder()
        {
            InitializeComponent();
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select an Otput Folder";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
                {
                    sw.WriteLine(folderBrowser.SelectedPath);
                }

                string outputPath = "";
                using (StreamReader sr = new StreamReader(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
                {
                    outputPath = sr.ReadLine();
                }
                SelectedFolderLabel.Text = "Selected Folder: " + outputPath;

                SelectFolderButton.BackColor = Color.SpringGreen;
            }
            else
            {
               return;
            }
        }

        private void TimerRecord_Tick(object sender, EventArgs e)
        {
            screenRecorder.RecordAudio();
            screenRecorder.RecordVideo();

            TimeLbl.Text = screenRecorder.GetElapsed();
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            if (screenRecorder.SelectFolder() == true)
            {
                Rectangle bounds = Screen.FromControl(this).Bounds;

                screenRecorder = new ScreenRecorder(bounds);

                timerRecord.Start();
                RecordButton.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Please select a folder before recording", "Error");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            RecordButton.BackColor = Color.White;
            timerRecord.Stop();
            screenRecorder.Stop();
            Application.Restart();
        }

        private void Recorder_Load(object sender, EventArgs e)
        {
            string outputPath = "";
            using (StreamReader sr = new StreamReader(@"D:\Repos\ScreenRecorder\WindowsFormsApp1\Folder.txt"))
            {
                outputPath = sr.ReadLine();
            }
            SelectedFolderLabel.Text = "Selected Folder: " + outputPath;
        }

        private void SelectedFolderLabel_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(SelectedFolderLabel.Text);
            MessageBox.Show("The path is copied to the buffer", "Attension", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
