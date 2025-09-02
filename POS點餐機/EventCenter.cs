using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class EventCenter
    {
        public static event EventHandler<RenderOrderModel> ReceivedRenderPanel;



        public static void RenderPanel(FlowLayoutPanel panel, string total)
        {
            RenderOrderModel renderOrder = new RenderOrderModel();
            renderOrder.Panel = panel;
            renderOrder.TotalAmount = total;

            ReceivedRenderPanel.Invoke(null, renderOrder);

        }

    }
}
