namespace VideoAnalyzerApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            BtnProcess2 = new Button();
            BtnClearLog = new Button();
            groupBox6 = new GroupBox();
            TxtLogs = new RichTextBox();
            BtnClear = new Button();
            BtnProcess = new Button();
            groupBox3 = new GroupBox();
            TxtResult = new RichTextBox();
            groupBox2 = new GroupBox();
            CmbLLM = new ComboBox();
            label7 = new Label();
            TxtDescribeVideo = new RichTextBox();
            TxtSystemMessage = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            BtnStopVideo = new Button();
            BtnPlay = new Button();
            BtnBrowse = new Button();
            label1 = new Label();
            TxtVideoPath = new TextBox();
            tabPage2 = new TabPage();
            BtnStop = new Button();
            BtnStart = new Button();
            groupBox5 = new GroupBox();
            BtnOpenFolder = new Button();
            BtnBrowseTargetFolder = new Button();
            label5 = new Label();
            TxtTargetFolder = new TextBox();
            groupBox4 = new GroupBox();
            BtnStopVideo2 = new Button();
            CmbVideoSource = new ComboBox();
            label6 = new Label();
            BtnPlayVideo2 = new Button();
            label4 = new Label();
            TxtVideoPath2 = new TextBox();
            statusStrip1 = new StatusStrip();
            StatusLbl = new ToolStripStatusLabel();
            BtnSamplePrompt = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(523, 576);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BtnProcess2);
            tabPage1.Controls.Add(BtnClearLog);
            tabPage1.Controls.Add(groupBox6);
            tabPage1.Controls.Add(BtnClear);
            tabPage1.Controls.Add(BtnProcess);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(515, 548);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Video Analyzer";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnProcess2
            // 
            BtnProcess2.Location = new Point(332, 282);
            BtnProcess2.Name = "BtnProcess2";
            BtnProcess2.Size = new Size(171, 23);
            BtnProcess2.TabIndex = 8;
            BtnProcess2.Text = "&Analyze Video From Frames";
            BtnProcess2.UseVisualStyleBackColor = true;
            // 
            // BtnClearLog
            // 
            BtnClearLog.Location = new Point(34, 282);
            BtnClearLog.Name = "BtnClearLog";
            BtnClearLog.Size = new Size(86, 23);
            BtnClearLog.TabIndex = 7;
            BtnClearLog.Text = "&Clear Logs";
            BtnClearLog.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(TxtLogs);
            groupBox6.Location = new Point(6, 443);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(506, 99);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "Logs";
            // 
            // TxtLogs
            // 
            TxtLogs.Location = new Point(9, 22);
            TxtLogs.Name = "TxtLogs";
            TxtLogs.Size = new Size(491, 71);
            TxtLogs.TabIndex = 7;
            TxtLogs.Text = "";
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(126, 282);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(86, 23);
            BtnClear.TabIndex = 5;
            BtnClear.Text = "&Clear Result";
            BtnClear.UseVisualStyleBackColor = true;
            // 
            // BtnProcess
            // 
            BtnProcess.Location = new Point(218, 282);
            BtnProcess.Name = "BtnProcess";
            BtnProcess.Size = new Size(108, 23);
            BtnProcess.TabIndex = 4;
            BtnProcess.Text = "&Analyze Video";
            BtnProcess.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TxtResult);
            groupBox3.Location = new Point(6, 311);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(506, 126);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Result";
            // 
            // TxtResult
            // 
            TxtResult.Location = new Point(9, 22);
            TxtResult.Name = "TxtResult";
            TxtResult.Size = new Size(491, 98);
            TxtResult.TabIndex = 7;
            TxtResult.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnSamplePrompt);
            groupBox2.Controls.Add(CmbLLM);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(TxtDescribeVideo);
            groupBox2.Controls.Add(TxtSystemMessage);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(6, 93);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(503, 183);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Analyzer";
            // 
            // CmbLLM
            // 
            CmbLLM.FormattingEnabled = true;
            CmbLLM.Location = new Point(55, 151);
            CmbLLM.Name = "CmbLLM";
            CmbLLM.Size = new Size(121, 23);
            CmbLLM.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 154);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 7;
            label7.Text = "LLM";
            // 
            // TxtDescribeVideo
            // 
            TxtDescribeVideo.Location = new Point(6, 103);
            TxtDescribeVideo.Name = "TxtDescribeVideo";
            TxtDescribeVideo.Size = new Size(491, 45);
            TxtDescribeVideo.TabIndex = 6;
            TxtDescribeVideo.Text = "";
            // 
            // TxtSystemMessage
            // 
            TxtSystemMessage.Location = new Point(6, 37);
            TxtSystemMessage.Name = "TxtSystemMessage";
            TxtSystemMessage.Size = new Size(491, 45);
            TxtSystemMessage.TabIndex = 5;
            TxtSystemMessage.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 4;
            label3.Text = "Video Describe Prompt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 3;
            label2.Text = "System Message";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnStopVideo);
            groupBox1.Controls.Add(BtnPlay);
            groupBox1.Controls.Add(BtnBrowse);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TxtVideoPath);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(503, 81);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Video";
            // 
            // BtnStopVideo
            // 
            BtnStopVideo.Location = new Point(267, 45);
            BtnStopVideo.Name = "BtnStopVideo";
            BtnStopVideo.Size = new Size(86, 23);
            BtnStopVideo.TabIndex = 4;
            BtnStopVideo.Text = "&Stop Video";
            BtnStopVideo.UseVisualStyleBackColor = true;
            // 
            // BtnPlay
            // 
            BtnPlay.Location = new Point(175, 45);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(86, 23);
            BtnPlay.TabIndex = 3;
            BtnPlay.Text = "&Play Video";
            BtnPlay.UseVisualStyleBackColor = true;
            // 
            // BtnBrowse
            // 
            BtnBrowse.Location = new Point(76, 45);
            BtnBrowse.Name = "BtnBrowse";
            BtnBrowse.Size = new Size(93, 23);
            BtnBrowse.TabIndex = 2;
            BtnBrowse.Text = "&Browse Video";
            BtnBrowse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "Video Path";
            // 
            // TxtVideoPath
            // 
            TxtVideoPath.Location = new Point(76, 16);
            TxtVideoPath.Name = "TxtVideoPath";
            TxtVideoPath.Size = new Size(421, 23);
            TxtVideoPath.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(BtnStop);
            tabPage2.Controls.Add(BtnStart);
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(515, 548);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Video Capture";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(426, 207);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(86, 23);
            BtnStop.TabIndex = 6;
            BtnStop.Text = "S&top Capture";
            BtnStop.UseVisualStyleBackColor = true;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(334, 207);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(86, 23);
            BtnStart.TabIndex = 5;
            BtnStart.Text = "&Start Capture";
            BtnStart.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtnOpenFolder);
            groupBox5.Controls.Add(BtnBrowseTargetFolder);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(TxtTargetFolder);
            groupBox5.Location = new Point(9, 120);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(503, 81);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Output Video Frames";
            // 
            // BtnOpenFolder
            // 
            BtnOpenFolder.Location = new Point(179, 45);
            BtnOpenFolder.Name = "BtnOpenFolder";
            BtnOpenFolder.Size = new Size(86, 23);
            BtnOpenFolder.TabIndex = 4;
            BtnOpenFolder.Text = "&Open Folder";
            BtnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseTargetFolder
            // 
            BtnBrowseTargetFolder.Location = new Point(87, 45);
            BtnBrowseTargetFolder.Name = "BtnBrowseTargetFolder";
            BtnBrowseTargetFolder.Size = new Size(86, 23);
            BtnBrowseTargetFolder.TabIndex = 3;
            BtnBrowseTargetFolder.Text = "Select &Folder";
            BtnBrowseTargetFolder.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 1;
            label5.Text = "Target Folder";
            // 
            // TxtTargetFolder
            // 
            TxtTargetFolder.Location = new Point(87, 16);
            TxtTargetFolder.Name = "TxtTargetFolder";
            TxtTargetFolder.Size = new Size(410, 23);
            TxtTargetFolder.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnStopVideo2);
            groupBox4.Controls.Add(CmbVideoSource);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(BtnPlayVideo2);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(TxtVideoPath2);
            groupBox4.Location = new Point(9, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(503, 108);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Input Video";
            // 
            // BtnStopVideo2
            // 
            BtnStopVideo2.Location = new Point(179, 76);
            BtnStopVideo2.Name = "BtnStopVideo2";
            BtnStopVideo2.Size = new Size(86, 23);
            BtnStopVideo2.TabIndex = 6;
            BtnStopVideo2.Text = "&Stop Video";
            BtnStopVideo2.UseVisualStyleBackColor = true;
            // 
            // CmbVideoSource
            // 
            CmbVideoSource.FormattingEnabled = true;
            CmbVideoSource.Location = new Point(87, 16);
            CmbVideoSource.Name = "CmbVideoSource";
            CmbVideoSource.Size = new Size(121, 23);
            CmbVideoSource.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 4;
            label6.Text = "Source";
            // 
            // BtnPlayVideo2
            // 
            BtnPlayVideo2.Location = new Point(87, 76);
            BtnPlayVideo2.Name = "BtnPlayVideo2";
            BtnPlayVideo2.Size = new Size(86, 23);
            BtnPlayVideo2.TabIndex = 3;
            BtnPlayVideo2.Text = "&Play Video";
            BtnPlayVideo2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 50);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 1;
            label4.Text = "Video Url";
            // 
            // TxtVideoPath2
            // 
            TxtVideoPath2.Location = new Point(87, 47);
            TxtVideoPath2.Name = "TxtVideoPath2";
            TxtVideoPath2.Size = new Size(410, 23);
            TxtVideoPath2.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLbl });
            statusStrip1.Location = new Point(0, 591);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(548, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLbl
            // 
            StatusLbl.Name = "StatusLbl";
            StatusLbl.Size = new Size(176, 17);
            StatusLbl.Text = "Welcome to Video Analyzer v0.1";
            // 
            // BtnSamplePrompt
            // 
            BtnSamplePrompt.Location = new Point(326, 154);
            BtnSamplePrompt.Name = "BtnSamplePrompt";
            BtnSamplePrompt.Size = new Size(171, 23);
            BtnSamplePrompt.TabIndex = 9;
            BtnSamplePrompt.Text = "&Sample Insurance Prompt";
            BtnSamplePrompt.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 613);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Video Analyzer v0.1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button BtnBrowse;
        private Label label1;
        private TextBox TxtVideoPath;
        private TabPage tabPage2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLbl;
        private Button BtnClear;
        private Button BtnProcess;
        private GroupBox groupBox3;
        private RichTextBox TxtResult;
        private RichTextBox TxtDescribeVideo;
        private RichTextBox TxtSystemMessage;
        private Label label3;
        private Label label2;
        private Button BtnPlay;
        private GroupBox groupBox4;
        private Button BtnPlayVideo2;
        private Label label4;
        private TextBox TxtVideoPath2;
        private GroupBox groupBox5;
        private Button BtnBrowseTargetFolder;
        private Label label5;
        private TextBox TxtTargetFolder;
        private ComboBox CmbVideoSource;
        private Label label6;
        private Button BtnStop;
        private Button BtnStart;
        private Button BtnOpenFolder;
        private ComboBox CmbLLM;
        private Label label7;
        private GroupBox groupBox6;
        private RichTextBox TxtLogs;
        private Button BtnClearLog;
        private Button BtnStopVideo;
        private Button BtnStopVideo2;
        private Button BtnProcess2;
        private Button BtnSamplePrompt;
    }
}
