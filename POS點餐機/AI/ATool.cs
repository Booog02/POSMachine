using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAgentPractice.Tools
{
    internal abstract class ATool
    {
        protected AIResponse.Args args;
        public ATool(AIResponse.Args args)
        {
            this.args = args;
        }
        public abstract AIResponse.Args RunTool();

    }
}
