using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAgentPractice.Tools
{
    internal abstract class BaseParameters
    {
        public string type { get; set; } = "object";
        public abstract List<string> required { get; }

        public abstract object properties { get; }


    }
}
