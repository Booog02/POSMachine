using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    //Model 專門放資料的地方
    internal class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int Subtotal
        {
            get
            {
                return Price * Amount;
            }
        }

        public MenuItem(string foodText, int amount)
        {
            string[] parts = foodText.Split('$');
            Name = parts[0].Trim();
            Price = int.Parse(parts[1].Trim());
            Amount = amount;

        }

    }
}
