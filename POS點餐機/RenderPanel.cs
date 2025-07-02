using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class RenderPanel
    {
        private FlowLayoutPanel OptionPanel;
        private EventHandler CheckedChanged;

        public RenderPanel(FlowLayoutPanel optionPanel, EventHandler checkedChanged)
        {
            OptionPanel = optionPanel;
            CheckedChanged = checkedChanged;
        }
    }
}
