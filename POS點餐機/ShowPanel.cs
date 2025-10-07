using AIAgentPractice;
using POS點餐機.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AIAgentPractice.AIRequest;

namespace POS點餐機
{
    internal class ShowPanel
    {

        // public static void Render(List<MenuItem> orders,FlowLayoutPane panel5)
        public static void Render(List<MenuItem> orders, AIResponse.Args aiResponse)
        {
            FlowLayoutPanel container = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 360,
                Height = 622,
            };


            for (int i = 0; i < orders.Count; i++)
            {
                MenuItem item = orders[i];

                FlowLayoutPanel itemContainer = new FlowLayoutPanel()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 350,
                    Height = 20,
                };

                Label Name = CreateLable(item.Name, 100);
                Label Price = CreateLable(item.Price.ToString(), 50);
                Label Amount = CreateLable(item.Amount.ToString(), 50);
                Label Subtotal = CreateLable(item.Subtotal.ToString(), 80);

                itemContainer.Controls.Add(Name);
                itemContainer.Controls.Add(Price);
                itemContainer.Controls.Add(Amount);
                itemContainer.Controls.Add(Subtotal);

                container.Controls.Add(itemContainer);
            }

            RenderOrderModel renderOrder = new RenderOrderModel();
            renderOrder.Panel = container;
            renderOrder.TotalAmount = orders.Sum(x => x.Subtotal).ToString();
            renderOrder.DiscountName = aiResponse?.name;
            renderOrder.Reason = aiResponse?.reason;
            //LINQ 有很多不同的功能函數可以用來資料搜尋/計算
            EventCenter.RenderPanel(renderOrder);

            //int total = 0;
            //foreach(MenuItem item in orders)
            //{
            //    total += item.Subtotal;
            //}

            //return container;
        }
        private static Label CreateLable(string Text, int width)
        {
            return new Label
            {
                Text = Text,
                Width = width
            };
        }
    }
}
