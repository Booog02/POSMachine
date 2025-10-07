using AIAgentPractice.Tools;
using System.Reflection;

namespace AIAgentPractice
{
    internal class AIRequest
    {
        public List<Content> contents { get; set; } = new List<Content>();
        public List<Tool> tools { get; set; } = new List<Tool>();

        public AIRequest()
        {
            this.tools.Add(new Tool());
        }

        public class Content
        {
            public string role { get; set; }
            public List<Part> parts { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
        }

        public class Tool
        {
            public List<BaseDeclaration> functionDeclarations { get; set; }

            public Tool()
            {
                functionDeclarations = Assembly.GetExecutingAssembly().DefinedTypes
               .Where(x => x.BaseType == typeof(BaseDeclaration)) //找出所有繼承 BaseDeclaration的型別
               .Select(x => (BaseDeclaration)Activator.CreateInstance(x)) //加工轉成 BaseDeclaration
               .ToList(); // 轉成 List<BaseDeclaration>
            }
        }


        public class PropertyType
        {
            public string type { get; set; } = "string";
        }

        public class PropertyField
        {
            public string type { get; set; }
            public string description { get; set; }
            public PropertyType items;

        }



    }
}
