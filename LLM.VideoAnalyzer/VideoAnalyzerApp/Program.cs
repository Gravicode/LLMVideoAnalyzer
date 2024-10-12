using System.Configuration;

namespace VideoAnalyzerApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Setup();
            Application.Run(new Form1());
        }

        static void Setup()
        {
            AppConstants.OpenAIKey = ConfigurationManager.AppSettings["OpenAIKey"];
            AppConstants.OpenAIModel = ConfigurationManager.AppSettings["OpenAIModel"];
            AppConstants.AzureOAIEndpoint = ConfigurationManager.AppSettings["AzureOAIEndpoint"];
            AppConstants.AzureOAIKey = ConfigurationManager.AppSettings["AzureOAIKey"];
            AppConstants.AzureOAIModel = ConfigurationManager.AppSettings["AzureOAIModel"];
            AppConstants.OllamaEndpoint = ConfigurationManager.AppSettings["OllamaEndpoint"];
            AppConstants.OllamaVisionModel = ConfigurationManager.AppSettings["OllamaVisionModel"];
            AppConstants.OllamaLlmModel = ConfigurationManager.AppSettings["OllamaLlmModel"];
            AppConstants.GithubToken = ConfigurationManager.AppSettings["GithubToken"];
            AppConstants.GithubModel = ConfigurationManager.AppSettings["GithubModel"];
        }
    }
}
 