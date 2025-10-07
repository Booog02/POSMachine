namespace AIAgentPractice
{
    internal class Program
    {

        static async Task Main(string[] args)//Task 代表這個方法會「非同步執行」，但不回傳結果，只是告訴呼叫端「我完成了」。
        {
            // 0905HW 完成Postman翻譯成C#可執行版本
            // 0912HW 思考如何封裝整包程式，建立一個AIAgent類別封裝，讓主程式透過該類別就能與AI互動，所有實作細節應該隱藏起來，如何無腦使用。

            AIAgent agent = new AIAgent();

            Console.WriteLine("助理:您好，請問需要什麼協助嗎?");
            while (true)
            {

                string userInput = Console.ReadLine();
                if (userInput == "結束")
                {
                    Console.WriteLine("助理:好的，結束本次對話。");
                    break;
                }

                AIResult result = await agent.SendCommand(userInput);

                if (result.CanRunTool)
                {
                    result.RunTool();
                }
                else
                {
                    Console.WriteLine("助理:" + result.ResponseText);
                }

            }
            Console.WriteLine("程式執行結束。");
            Console.ReadKey();
        }
    }
}
