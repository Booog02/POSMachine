using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class Test
    {

        public string name { get; set; }
        public string lastname { get; set; }
        public Report[] report { get; set; }

        public class Report
        {
            public string subject { get; set; }
            public int score { get; set; }
        }

    }
}
