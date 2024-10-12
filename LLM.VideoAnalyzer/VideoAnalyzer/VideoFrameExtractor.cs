using Microsoft.Extensions.AI;
using OpenCvSharp;
using SkiaSharp;
using System;

namespace VideoAnalyzer
{
    public class VideoFrameExtractor
    {
        public VideoFrameExtractor()
        {
          
        }
        public List<byte[]> ExtractVideoFrames(List<string> ImageList)
        {
            try
            {
                List<byte[]> images = new();
                foreach (var image in ImageList)
                {
                    if (File.Exists(image))
                    {
                        var skimage = SKImage.FromEncodedData(image);
                        var input = SKBitmap.FromImage(skimage);

                        // Create a memory stream to hold the image data
                        using var ms = new MemoryStream();

                        // Encode the bitmap to a PNG format in the memory stream
                        input.Encode(ms, SKEncodedImageFormat.Jpeg, 100);

                        // Convert the memory stream to a byte array
                        byte[] imageBytes = ms.ToArray();
                        images.Add(imageBytes);
                    }
                }
                return images;
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }

            return default;
        }
        public List<byte[]> ExtractVideoFrames(string videoFile, int NumberOfFrames=10)
        {
            try
            {
                List<byte[]> images = new();
                // Extract the frames from the video
                var video = new VideoCapture(videoFile);
                //var frames = new List<Mat>();
                while (video.IsOpened())
                {
                    var frame = new Mat();
                    if (!video.Read(frame) || frame.Empty())
                        break;
                    // resize the frame to half of its size if the with is greater than 800
                    if (frame.Width > 800)
                    {
                        Cv2.Resize(frame, frame, new OpenCvSharp.Size(frame.Width / 2, frame.Height / 2));
                    }
                    //frames.Add(frame);
                    var byteImg = frame.ToBytes(".jpg");
                    images.Add(byteImg);
                }
                video.Release();
                // filter by number of frames
                // create the OpenAI files that represent the video frames
                int step = (int)Math.Ceiling((double)images.Count / NumberOfFrames);

                // show in the console the total number of frames and the step that neeeds to be taken to get the desired number of frames for the video analysis
                LogHelpers.WriteLog($"Video total number of frames: {images.Count}");
                LogHelpers.WriteLog($"Get 1 frame every [{step}] to get the [{NumberOfFrames}] frames for analysis");
                var newList = new List<byte[]>();
                for (int i = 0; i < images.Count; i += step)
                {  
                    newList.Add(images[i]);
                }
                return newList;
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }

            return default;
        }
    }
}
