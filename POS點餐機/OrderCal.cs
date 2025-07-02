using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class OrderCal
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void ClearOrders()
        {
            Orders.Clear();
        }

        public int CalculateTotal()
        {
            int total = 0;
            for (int i = 0; i < Orders.Count; i++)
            {
                total += Orders[i].Note;
            }
            return total;
        }
    }
}
