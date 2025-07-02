using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class Order
    {
        public MenuItem Food { get; set; }
        public int Amount { get; set; }
        public int Note
        {
            get
            {
                return Food.Price * Amount;
            }
        }

        public Order(MenuItem food, int amount)
        {
            Food = food;
            Amount = amount;
        }
    }
}
