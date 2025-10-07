using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAgentPractice.Tools
{
    internal abstract class BaseDeclaration
    {
        /// <summary>
        /// 該欄位會用來定義工具的名稱，需要給予namespace+toolName 就可以透過反射自動呼叫該工具。
        /// 例如: <c>AIAgentPractice.Tools.Weather.WeatherTool</c>
        /// </summary>
        public abstract string name { get; }
        public abstract string description { get; }
        public abstract BaseParameters parameters { get; }
    }
}
