namespace ScreenRecorder
{
    partial class Recorder
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recorder));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TimeLbl = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelectedFolderLabel = new System.Windows.Forms.Label();
            this.timerRecord = new System.Windows.Forms.Timer(this.components);
            this.TextRunTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.TimeLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.StopButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SelectFolderButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RecordButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TimeLbl
            // 
            this.TimeLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLbl.Location = new System.Drawing.Point(152, 5);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(88, 24);
            this.TimeLbl.TabIndex = 3;
            this.TimeLbl.Text = "00:00:00";
            this.TimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(133, 38);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(124, 29);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Location = new System.Drawing.Point(3, 3);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(124, 29);
            this.SelectFolderButton.TabIndex = 0;
            this.SelectFolderButton.Text = "Select Folder";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(3, 38);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(124, 29);
            this.RecordButton.TabIndex = 1;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.SelectedFolderLabel);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 24);
            this.panel1.TabIndex = 5;
            // 
            // SelectedFolderLabel
            // 
            this.SelectedFolderLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectedFolderLabel.AutoSize = true;
            this.SelectedFolderLabel.Location = new System.Drawing.Point(3, 5);
            this.SelectedFolderLabel.Name = "SelectedFolderLabel";
            this.SelectedFolderLabel.Size = new System.Drawing.Size(81, 13);
            this.SelectedFolderLabel.TabIndex = 4;
            this.SelectedFolderLabel.Text = "Selected Folder";
            this.SelectedFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SelectedFolderLabel.Click += new System.EventHandler(this.SelectedFolderLabel_Click);
            // 
            // timerRecord
            // 
            this.timerRecord.Interval = 15;
            this.timerRecord.Tick += new System.EventHandler(this.TimerRecord_Tick);
            // 
            // TextRunTimer
            // 
            this.TextRunTimer.Interval = 300;
            this.TextRunTimer.Tick += new System.EventHandler(this.TextRunTimer_Tick);
            // 
            // Recorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 100);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Recorder";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Recorder";
            this.Load += new System.EventHandler(this.Recorder_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.Timer timerRecord;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Label SelectedFolderLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer TextRunTimer;
    }
}

