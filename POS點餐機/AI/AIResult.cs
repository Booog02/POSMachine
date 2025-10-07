using AIAgentPractice.Tools;

namespace AIAgentPractice
{
    internal class AIResult
    {
        public string ResponseText { get; set; }
        public bool CanRunTool { get; set; } = true;
        private AIResponse response;
        public AIResult(AIResponse response)
        {
            this.response = response;
            if (response.candidates[0].content.parts[0].text != null)
            {
                ResponseText = response.candidates[0].content.parts[0].text;
                CanRunTool = false;
            }
            else
            {
                ResponseText = "已經幫你設定好了喔!";
            }
        }

        public AIResponse.Args RunTool()
        {
            if (CanRunTool)
            {
                string funcName = response.candidates[0].content.parts[0].functionCall.name;
                Type toolType = Type.GetType("POS點餐機." + funcName);
                ATool tools = (ATool)Activator.CreateInstance(toolType, new object[] { response.candidates[0].content.parts[0].functionCall.args });
                return tools.RunTool();

            }

            throw new Exception("參數尚未齊全目前無法執行該工具，請確認 CanRunTool 為True 才能執行");
        }
    }
}
