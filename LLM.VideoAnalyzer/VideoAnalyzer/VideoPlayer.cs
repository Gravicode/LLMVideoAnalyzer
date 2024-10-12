using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAnalyzer
{

    public class VideoPlayer
    {
        public Thread PlayerThread { get; set; }
        public string VideoUrl { get; set; }
        public bool IsPlaying { get; set; }
        public CancellationTokenSource TokenSource { get; set; }
        public VideoCapture capture { get; set; }
     

        public VideoSources VideoSource { get; set; } = VideoSources.WebCam;

        public VideoPlayer()
        {
           
        }
        public void Start(string videoUrl = "")
        {
            if (IsPlaying) return;
            if (!string.IsNullOrEmpty(videoUrl))
            {
                VideoSource = VideoSources.IPCam;
                this.VideoUrl = videoUrl;
            }
            else
            {
                VideoSource = VideoSources.WebCam;
            }
            capture = VideoSource == VideoSources.WebCam ? new VideoCapture(0) : new VideoCapture(VideoUrl);
            if (!capture.IsOpened())
            {
                Console.WriteLine($"Failed to play");
                return;
            }
            PlayerThread = new(Capture);
            PlayerThread.Start();
        }
        public void Stop()
        {
            if (!IsPlaying) return;
            TokenSource?.Cancel();
        }
        void Capture()
        {
            TokenSource = new CancellationTokenSource();
            var token = TokenSource.Token;
            // Create a Mat object to hold the frame data
            using var frame = new Mat();
            IsPlaying = true;
            // Create a window to display the camera feed
            using var window = new Window("Camera/Video");

            // Create a Stopwatch to measure time
            var stopwatch = new Stopwatch();
            int frameCount = 0;
            double fps = 0.0;
            try
            {
                while (true)
                {
                    stopwatch.Restart();

                    // Capture a frame from the camera
                    capture.Read(frame);

                    // If the frame is empty, break the loop
                    if (frame.Empty())
                        break;


                    // Calculate FPS
                    frameCount++;
                    if (frameCount >= 10)
                    {
                        stopwatch.Stop();
                        fps = frameCount / (stopwatch.ElapsedMilliseconds / 1000.0);
                        frameCount = 0;
                    }

                    // Display FPS on the frame
                    Cv2.PutText(frame, $"FPS: {fps:F2}", new Point(10, 30), HersheyFonts.HersheySimplex, 1, Scalar.White, 2);

                    // Show the frame in the window
                    window.ShowImage(frame);

                    // Wait for 1 ms and check if the 'q' key is pressed
                    if (Cv2.WaitKey(1) == 'q')
                        break;
                    if (token.IsCancellationRequested) break;
                }
                
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            finally
            {
                IsPlaying = false;
            }

        }
    }
}
