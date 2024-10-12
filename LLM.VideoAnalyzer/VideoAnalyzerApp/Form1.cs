using System.Diagnostics;
using VideoAnalyzer;

namespace VideoAnalyzerApp
{
    public partial class Form1 : Form
    {
        VideoAnalyzer.IVideoAnalyzer analyzer { set; get; }
        VideoAnalyzer.VideoPlayer videoPlayer { set; get; }
        VideoAnalyzer.VideoPlayer videoPlayer2 { set; get; }
        VideoAnalyzer.VideoFrameCapture videoCapture { set; get; }
        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        void Setup()
        {
            this.videoCapture = new VideoAnalyzer.VideoFrameCapture();
            this.videoPlayer = new VideoAnalyzer.VideoPlayer();
            this.videoPlayer2 = new VideoAnalyzer.VideoPlayer();
            LogHelpers.LogReceived += (a, b) =>
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    TxtLogs.AppendText(b.Message + "\n");
                });
            };
            CmbLLM.Items.Clear();
            CmbLLM.Items.AddRange(["Open AI", "Azure AI", "Ollama", "Github Model"]);
            CmbLLM.SelectedIndex = 0;
            CmbLLM.SelectedIndexChanged += (a, b) => { SetupAnalyzer(); };

            CmbVideoSource.Items.Clear();
            CmbVideoSource.Items.AddRange(["Webcam", "IPCam/Video Url"]);
            CmbVideoSource.SelectedIndex = 0;
            TxtTargetFolder.Text = this.videoCapture.TargetFolder;
            TxtSystemMessage.Text = IVideoAnalyzer.DefaultSystemMessage;
            TxtDescribeVideo.Text = IVideoAnalyzer.DefaultVideoAnalyzePrompt;

            TxtVideoPath.Text = "http://pendelcam.kip.uni-heidelberg.de/mjpg/video.mjpg";
            TxtVideoPath2.Text = "http://pendelcam.kip.uni-heidelberg.de/mjpg/video.mjpg";
            BtnBrowseTargetFolder.Click += (a, b) =>
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select a folder";
                    folderBrowserDialog.ShowNewFolderButton = false;

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderBrowserDialog.SelectedPath;
                        TxtTargetFolder.Text = selectedPath;
                        //MessageBox.Show($"Selected folder: {selectedPath}");
                    }
                }
            };
            BtnProcess2.Click += async(a, b) =>
            {
                string[] images = null; 
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select a folder with image frames";
                    folderBrowserDialog.ShowNewFolderButton = false;

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderBrowserDialog.SelectedPath;
                        images = Directory.GetFiles(selectedPath,"*.jpg");
                        if(images == null || images.Length <= 0)
                        {
                            StatusLbl.Text = "Images not found..";
                            return;
                        }
                        if (string.IsNullOrEmpty(TxtSystemMessage.Text))
                        {
                            StatusLbl.Text = "Please input system message";
                            return;
                        }
                        if (string.IsNullOrEmpty(TxtDescribeVideo.Text))
                        {
                            StatusLbl.Text = "Please input describe video prompt";
                            return;
                        }
                        if (string.IsNullOrEmpty(TxtVideoPath.Text))
                        {
                            StatusLbl.Text = "Please select video first";
                            return;
                        }
                        if (analyzer is null)
                        {
                            SetupAnalyzer();
                        }
                        SetStateControl(false);
                        try
                        {
                            StatusLbl.Text = "Analyzing frames.. please wait..";
                            var result = await analyzer.AnalyzeWithCustomPrompt(images.ToList(), TxtSystemMessage.Text, TxtDescribeVideo.Text);
                            TxtResult.Text = result;
                        }
                        catch (Exception ex)
                        {
                            LogHelpers.WriteLog(ex);
                        }
                        finally
                        {
                            SetStateControl(true);
                        }
                    }
                }
                
            };
            BtnClear.Click += (a, b) =>
            {
                TxtResult.Clear();
            };
            BtnClearLog.Click += (a, b) =>
            {
                TxtLogs.Clear();
            };
            BtnBrowse.Click += (a, b) =>
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.wmv";
                    openFileDialog.Title = "Open Video File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = openFileDialog.FileName;
                        TxtVideoPath.Text = path;
                    }
                }
            };
            BtnOpenFolder.Click += (a, b) => { };
            BtnPlay.Click += (a, b) =>
            {
                if (string.IsNullOrEmpty(TxtVideoPath.Text))
                {
                    StatusLbl.Text = "Please select video first";
                    return;
                }
                this.videoPlayer.Start(TxtVideoPath.Text);


            };
            BtnOpenFolder.Click += (a, b) =>
            {
                if (string.IsNullOrEmpty(TxtTargetFolder.Text))
                {
                    StatusLbl.Text = "Please select target folder";
                    return;
                }
                Process.Start("explorer.exe", TxtTargetFolder.Text);

            };
            BtnStart.Click += (a, b) =>
            {
                if (string.IsNullOrEmpty(TxtTargetFolder.Text))
                {
                    StatusLbl.Text = "Please select target folder";
                    return;
                }
                this.videoCapture.TargetFolder = TxtTargetFolder.Text;
                switch (CmbVideoSource.SelectedIndex)
                {
                    case 0:
                        this.videoCapture.Start();
                        break;
                    case 1:
                        if (string.IsNullOrEmpty(TxtVideoPath2.Text))
                        {
                            StatusLbl.Text = "Please select video first";
                            return;
                        }
                        this.videoCapture.Start(TxtVideoPath2.Text);
                        break;
                }
            };
            BtnStop.Click += (a, b) =>
            {
                this.videoCapture.Stop();
            };
            BtnProcess.Click += async (a, b) =>
            {
                if (string.IsNullOrEmpty(TxtSystemMessage.Text))
                {
                    StatusLbl.Text = "Please input system message";
                    return;
                }
                if (string.IsNullOrEmpty(TxtDescribeVideo.Text))
                {
                    StatusLbl.Text = "Please input describe video prompt";
                    return;
                }
                if (string.IsNullOrEmpty(TxtVideoPath.Text))
                {
                    StatusLbl.Text = "Please select video first";
                    return;
                }
                if (analyzer is null)
                {
                    SetupAnalyzer();
                }
                SetStateControl(false);
                try
                {
                    StatusLbl.Text = "Analyzing video.. please wait..";
                    var result = await analyzer.AnalyzeWithCustomPrompt(TxtVideoPath.Text, TxtSystemMessage.Text, TxtDescribeVideo.Text);
                    TxtResult.Text = result;
                }
                catch (Exception ex)
                {
                    LogHelpers.WriteLog(ex);
                }
                finally
                {
                    SetStateControl(true);
                }
            };
            BtnStopVideo.Click += (a, b) =>
            {
                this.videoPlayer.Stop();
            };
            BtnStopVideo2.Click += (a, b) =>
            {
                this.videoPlayer2.Stop();
            };
            BtnPlayVideo2.Click += (a, b) =>
        {
            switch (CmbVideoSource.SelectedIndex)
            {
                case 0:
                    this.videoPlayer2.Start();
                    break;
                case 1:
                    if (string.IsNullOrEmpty(TxtVideoPath2.Text))
                    {
                        StatusLbl.Text = "Please select video first";
                        return;
                    }
                    this.videoPlayer2.Start(TxtVideoPath2.Text);
                    break;
            }
        };
        }
        void SetStateControl(bool State)
        {
            BtnBrowse.Enabled = State;
            BtnStart.Enabled = State;
            BtnStop.Enabled = State;
            BtnProcess.Enabled = State;
            BtnBrowseTargetFolder.Enabled = State;
            BtnClear.Enabled = State;
            BtnClearLog.Enabled = State;
            BtnPlay.Enabled = State;
            BtnPlayVideo2.Enabled = State;
            CmbLLM.Enabled = State;
            CmbVideoSource.Enabled = State;
            BtnStopVideo.Enabled = State;
            BtnStopVideo.Enabled = State;
            BtnProcess2.Enabled = State;

        }

        void SetupAnalyzer()
        {
            try
            {
                switch (CmbLLM.SelectedIndex)
                {
                    case 0:
                        analyzer = new VideoAnalyzer.OpenAIVideoAnalyzer(AppConstants.OpenAIKey, AppConstants.OpenAIModel);
                        break;
                    case 1:
                        analyzer = new VideoAnalyzer.AzureOpenAIVideoAnalyzer(AppConstants.AzureOAIEndpoint, AppConstants.AzureOAIKey, AppConstants.AzureOAIModel);
                        break;
                    case 2:
                        analyzer = new VideoAnalyzer.OllamaVideoAnalyzer(AppConstants.OllamaEndpoint, AppConstants.OllamaVisionModel, AppConstants.OllamaLlmModel);
                        break;
                    case 3:
                        analyzer = new VideoAnalyzer.GithubModelVideoAnalyzer(AppConstants.GithubToken, AppConstants.GithubModel);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }

        }

    }
}
