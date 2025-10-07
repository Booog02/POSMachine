using Newtonsoft.Json;
using System.Configuration;
using static AIAgentPractice.AIRequest;

namespace AIAgentPractice
{
    internal class AIAgent
    {
        private string apiKey;
        private AIRequest aiRequest = new AIRequest();
        public AIAgent(string apiKey)
        {
            this.apiKey = apiKey;
            this.AddPrompt(UserType.Model, "你做為一個AI助理，請直接根據使用者的需求，協助幫他設定各種所需要的任務，你現在可以設定燈光和記錄會議行程");
        }

        public AIAgent()
        {
            this.apiKey = ConfigurationManager.AppSettings["x-goog-api-key"];

            this.AddPrompt(UserType.Model, "你做為一個AI助理，請直接根據使用者的需求，透過你現有的Toolsx來協助使用者幫他設定各種所需要的任務。");

        }

        public void AddPrompt(UserType userType, string message)
        {
            aiRequest.contents.Add(new AIRequest.Content
            {
                role = userType.ToString(),
                parts = new List<Part>
                {
                    new Part { text = message } }
            });

        }
        public async Task<AIResult> SendCommand(string userInput)
        {
            AddPrompt(UserType.User, userInput);

            string requestContent = JsonConvert.SerializeObject(aiRequest);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent");
            request.Headers.Add("x-goog-api-key", apiKey);
            var content = new StringContent(requestContent, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            AIResponse aIResponse = JsonConvert.DeserializeObject<AIResponse>(responseString);

            var result = new AIResult(aIResponse);
            AddPrompt(UserType.Model, result.ResponseText);

            return result;
        }

    }
}
