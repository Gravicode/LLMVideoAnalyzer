using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAnalyzer
{
    public enum VideoSources { IPCam, WebCam }
    public class VideoFrameCapture
    {
        public Thread CaptureThread { get; set; }
        public string VideoUrl { get; set; }
        public bool IsCapturing { get; set; }
        public CancellationTokenSource TokenSource { get; set; }
        public VideoCapture capture { get; set; } 
        public string TargetFolder { get; set; } 
        
        public VideoSources VideoSource { get; set; } = VideoSources.WebCam;

        public VideoFrameCapture()
        {
            var myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            TargetFolder = Path.Combine(myDoc,"VideoCapture");
            if(!Directory.Exists(TargetFolder))
            {
                Directory.CreateDirectory(TargetFolder);
            }
        }
        public void Start(string videoUrl="")
        {
            if (IsCapturing) return;
            if (!string.IsNullOrEmpty(videoUrl))
            {
                VideoSource = VideoSources.IPCam;
                this.VideoUrl = videoUrl;
            }
            else
            {
                VideoSource = VideoSources.WebCam;
            }
            capture = VideoSource == VideoSources.WebCam ? new VideoCapture(0): new VideoCapture(VideoUrl);
            if (!capture.IsOpened())
            {
                Console.WriteLine($"Failed to capture");
                return;
            }
            CaptureThread = new(Capture);
            CaptureThread.Start();
        }
        public void Stop()
        {
            if (!IsCapturing) return;
            TokenSource?.Cancel();
        }
        void Capture()
        {
            TokenSource = new CancellationTokenSource();
            var token = TokenSource.Token; 
            // Create a Mat object to hold the frame data
            using var frame = new Mat();
            IsCapturing = true;
            try
            {
                while (true)
                {
                    // Capture a frame from the camera
                    capture.Read(frame);

                    // If the frame is empty, break the loop
                    if (frame.Empty())
                        break;

                    // save the frame
                    string frameFileName = Path.Combine(TargetFolder, $"frame_{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}.jpg");
                    frame.SaveImage(frameFileName);

                    // show in the console the frame file name
                    Console.WriteLine($"Saving frame FileName: {frameFileName}");
                    if (token.IsCancellationRequested) break;
                }
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            finally
            {
                IsCapturing = false;
            }

        }
    }
}
