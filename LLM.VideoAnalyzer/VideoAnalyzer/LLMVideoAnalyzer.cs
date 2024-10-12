using Azure.AI.Inference;
using Azure;
using OpenAI;
using Microsoft.Extensions.AI;
using System.Net;
using Azure.AI.OpenAI;
using System.ClientModel;

namespace VideoAnalyzer
{
    public interface IVideoAnalyzer
    {
        VideoFrameExtractor extractor { get; set; }
        IChatClient chatClient { set; get; }
        public static string DefaultSystemMessage = @"You are a useful assistant. When you receive a group of images, they are frames of a unique video.";
        public static string DefaultVideoAnalyzePrompt = @"The attached frames represent a video. Describe the whole video story, do not describe frame by frame.";
        string SystemMessage { get; set; } 
        string VideoAnalyzePrompt { get; set; }
        Task<string> Analyze(string VideoFilePath,int NumberOfFrame=10) => AnalyzeWithCustomPrompt(VideoFilePath,DefaultSystemMessage,DefaultVideoAnalyzePrompt,NumberOfFrame);
        Task<string> AnalyzeWithCustomPrompt(string VideoFilePath,string SystemMessage,string DescribeVideoPrompt, int NumberOfFrame=10);
        Task<string> AnalyzeWithCustomPrompt(List<string> ListImage, string SystemMessage,string DescribeVideoPrompt);
    }
    public class OpenAIVideoAnalyzer : IVideoAnalyzer
    {
        public VideoFrameExtractor extractor { get; set; }
        public string SystemMessage { set; get; }
        public string VideoAnalyzePrompt { set; get; }
        public IChatClient chatClient { set; get; }

        public OpenAIVideoAnalyzer(string OpenAIKey,string ModelId= "gpt-4o-mini")
        {
            extractor = new();
            chatClient = new OpenAIClient(apiKey: OpenAIKey).AsChatClient(ModelId);
        }
        public async Task<string> AnalyzeWithCustomPrompt(string VideoFilePath, string SystemMessage, string DescribeVideoPrompt, int NumberOfFrame)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(VideoFilePath, NumberOfFrame);

                List<ChatMessage> messages =
                [
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.System, SystemMessage),
                new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, DescribeVideoPrompt),
            ];

                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    var message = new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic]);
                    messages.Add(message);
                }

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(messages);

                LogHelpers.WriteLog($"\n[OpenAI APIs response using Microsoft Extensions for AI]: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }

        public async Task<string> AnalyzeWithCustomPrompt(List<string> ListImage, string SystemMessage, string DescribeVideoPrompt)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(ListImage);

                List<ChatMessage> messages =
                [
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.System, SystemMessage),
                new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, DescribeVideoPrompt),
            ];

                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    var message = new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic]);
                    messages.Add(message);
                }

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(messages);

                LogHelpers.WriteLog($"\n[OpenAI APIs response using Microsoft Extensions for AI]: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }
    }
    public class GithubModelVideoAnalyzer : IVideoAnalyzer
    {
        public VideoFrameExtractor extractor { get; set; }
        public string SystemMessage { set; get; }
        public string VideoAnalyzePrompt { set; get; }
        public IChatClient chatClient { set; get; }

        public GithubModelVideoAnalyzer(string GithubToken, string ModelId = "gpt-4o-mini")
        {
            extractor = new();
            chatClient = new ChatCompletionsClient(
        endpoint: new Uri("https://models.inference.ai.azure.com"),
        new AzureKeyCredential(GithubToken))
        .AsChatClient(ModelId);
        }
        public async Task<string> AnalyzeWithCustomPrompt(string VideoFilePath, string SystemMessage, string DescribeVideoPrompt, int NumberOfFrame)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(VideoFilePath, NumberOfFrame);

                List<ChatMessage> messages =
                [
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.System, SystemMessage),
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, DescribeVideoPrompt),
            ];

                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    var message = new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic]);
                    messages.Add(message);
                }

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(messages);

                LogHelpers.WriteLog($"\n[GitHub Models response using Microsoft Extensions for AI]: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }

        public async Task<string> AnalyzeWithCustomPrompt(List<string> ListImage, string SystemMessage, string DescribeVideoPrompt)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(ListImage);

                List<ChatMessage> messages =
                [
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.System, SystemMessage),
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, DescribeVideoPrompt),
            ];

                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    var message = new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic]);
                    messages.Add(message);
                }

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(messages);

                LogHelpers.WriteLog($"\n[GitHub Models response using Microsoft Extensions for AI]: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }
    }
    public class OllamaVideoAnalyzer : IVideoAnalyzer
    {
        IChatClient chatClientImageAnalyzer { set; get; }
        public VideoFrameExtractor extractor { get; set; }
        public string SystemMessage { set; get; }
        public string VideoAnalyzePrompt { set; get; }
        public IChatClient chatClient { set; get; }

        public OllamaVideoAnalyzer(string OllamaEndpoint = "http://localhost:11434/", string ModelVisionId = "llava:7b", string ModelId = "llama3.2")
        {
            extractor = new();
            chatClientImageAnalyzer =
    new OllamaChatClient(new Uri(OllamaEndpoint), ModelVisionId);
            chatClient =
                new OllamaChatClient(new Uri(OllamaEndpoint), ModelId);
        }
        public async Task<string> AnalyzeWithCustomPrompt(string VideoFilePath, string SystemMessage, string DescribeVideoPrompt, int NumberOfFrame)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(VideoFilePath, NumberOfFrame);
                
                List<string> imageAnalysisResponses = new();
                var i = 0;
                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    List<ChatMessage> messages =
                    [
                        new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, @$"The image represents a frame of a video. Describe the image in a single sentence. Frame Number: [{i}]

In example:
Frame Number: 0
A view of a fire station with red garage doors. The sidewalk is empty, and there are yellow posts in front of the garage doors. Surrounding buildings are visible in the background, along with a clear blue sky.

Frame Number: 1
The same fire station is shown, but now a fire truck is partially visible, parked in front of the garage doors. The scene retains the same urban backdrop, with nearby buildings and trees.

Frame Number: 2
The fire truck is now seen moving out of the station and onto the street. The background features a tall black building and additional urban elements, including traffic signs and trees."),
        new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic])
                     ];
                    // send the messages to the assistant
                    var imageAnalysis = await chatClientImageAnalyzer.CompleteAsync(messages);
                    var imageAnalysisResponse = $"{imageAnalysis.Message.Text}\n";
                    imageAnalysisResponses.Add(imageAnalysisResponse);

                    LogHelpers.WriteLog($"Frame: {i}\n{imageAnalysisResponse}");
                    i++;
                }

                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("Start build prompt");
                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("");
                var imageAnalysisResponseCollection = string.Empty;

                foreach (var desc in imageAnalysisResponses)
                {
                    imageAnalysisResponseCollection += $"\n[FRAME ANALYSIS START]{desc}[FRAME ANALYSIS END]";
                }

                var userPrompt = $"The texts below represets a video analysis from different frames from the video. Using that frames description, describe the video. Do not describe individual frames. Do not mention the frame number of frame description. Using the frames information infer the content of the video.\n{imageAnalysisResponseCollection}";

                // display the full user prompt 
                LogHelpers.WriteLog(userPrompt);
                LogHelpers.WriteLog("");

                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("Start video analysis");
                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("");

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(userPrompt);
                LogHelpers.WriteLog("MEAI Chat Client using Ollama Response: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }

        public async Task<string> AnalyzeWithCustomPrompt(List<string> ListImage, string SystemMessage, string DescribeVideoPrompt)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(ListImage);

                List<string> imageAnalysisResponses = new();
                var i = 0;
                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    List<ChatMessage> messages =
                    [
                        new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, @$"The image represents a frame of a video. Describe the image in a single sentence. Frame Number: [{i}]

In example:
Frame Number: 0
A view of a fire station with red garage doors. The sidewalk is empty, and there are yellow posts in front of the garage doors. Surrounding buildings are visible in the background, along with a clear blue sky.

Frame Number: 1
The same fire station is shown, but now a fire truck is partially visible, parked in front of the garage doors. The scene retains the same urban backdrop, with nearby buildings and trees.

Frame Number: 2
The fire truck is now seen moving out of the station and onto the street. The background features a tall black building and additional urban elements, including traffic signs and trees."),
        new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic])
                     ];
                    // send the messages to the assistant
                    var imageAnalysis = await chatClientImageAnalyzer.CompleteAsync(messages);
                    var imageAnalysisResponse = $"{imageAnalysis.Message.Text}\n";
                    imageAnalysisResponses.Add(imageAnalysisResponse);

                    LogHelpers.WriteLog($"Frame: {i}\n{imageAnalysisResponse}");
                    i++;
                }

                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("Start build prompt");
                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("");
                var imageAnalysisResponseCollection = string.Empty;

                foreach (var desc in imageAnalysisResponses)
                {
                    imageAnalysisResponseCollection += $"\n[FRAME ANALYSIS START]{desc}[FRAME ANALYSIS END]";
                }

                var userPrompt = $"The texts below represets a video analysis from different frames from the video. Using that frames description, describe the video. Do not describe individual frames. Do not mention the frame number of frame description. Using the frames information infer the content of the video.\n{imageAnalysisResponseCollection}";

                // display the full user prompt 
                LogHelpers.WriteLog(userPrompt);
                LogHelpers.WriteLog("");

                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("Start video analysis");
                LogHelpers.WriteLog("====================================================");
                LogHelpers.WriteLog("");

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(userPrompt);
                LogHelpers.WriteLog("MEAI Chat Client using Ollama Response: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }
    }
    public class AzureOpenAIVideoAnalyzer : IVideoAnalyzer
    {
        public VideoFrameExtractor extractor { get; set; }
        public string SystemMessage { set; get; }
        public string VideoAnalyzePrompt { set; get; }
        public IChatClient chatClient { set; get; }

        public AzureOpenAIVideoAnalyzer(string endpoint,string apiKey, string ModelId)
        {
            var credential = new ApiKeyCredential(apiKey);
            extractor = new();
            chatClient = new AzureOpenAIClient(new Uri(endpoint), credential)
            .AsChatClient(modelId: ModelId);
        }
        public async Task<string> AnalyzeWithCustomPrompt(string VideoFilePath, string SystemMessage, string DescribeVideoPrompt, int NumberOfFrame)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(VideoFilePath, NumberOfFrame);

                List<ChatMessage> messages =
                [
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.System, SystemMessage),
                new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, DescribeVideoPrompt),
            ];

                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    var message = new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic]);
                    messages.Add(message);
                }

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(messages);

                LogHelpers.WriteLog($"\n[Azure OpenAI Services response using Microsoft Extensions for AI]: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }

        public async Task<string> AnalyzeWithCustomPrompt(List<string> ListImage, string SystemMessage, string DescribeVideoPrompt)
        {
            try
            {
                var frames = extractor.ExtractVideoFrames(ListImage);

                List<ChatMessage> messages =
                [
                    new ChatMessage(Microsoft.Extensions.AI.ChatRole.System, SystemMessage),
                new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, DescribeVideoPrompt),
            ];

                foreach (var frame in frames)
                {
                    // read the image bytes, create a new image content part and add it to the messages
                    AIContent aic = new ImageContent(frame, "image/jpeg");
                    var message = new ChatMessage(Microsoft.Extensions.AI.ChatRole.User, [aic]);
                    messages.Add(message);
                }

                // send the messages to the assistant
                var response = await chatClient.CompleteAsync(messages);

                LogHelpers.WriteLog($"\n[Azure OpenAI Services response using Microsoft Extensions for AI]: ");
                LogHelpers.WriteLog(response.Message.ToString());
                return response.Message.ToString();
            }
            catch (Exception ex)
            {
                LogHelpers.WriteLog(ex);
            }
            return string.Empty;
        }
    }
}
