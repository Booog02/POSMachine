using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Models
{
    internal class MenuModel
    {
        public Menu[] Menus { get; set; }
        public Discount[] Discounts { get; set; }


        public class Menu
        {
            public string Type { get; set; }
            public Item[] Items { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Discount
        {
            public string Strategy { get; set; }
            public string Name { get; set; }
            public Condition[] Conditions { get; set; }
            public Reward[] Rewards { get; set; }
        }

        public class Condition
        {
            public string BuyItem { get; set; }
            public int BuyQuantity { get; set; }
            public int Price { get; set; }
        }

        public class Reward
        {
            public string FreeItem { get; set; }
            public int FreeQuantity { get; set; }
            public string RewardType { get; set; }
            public float DiscountRate { get; set; }
            public int PackagePrice { get; set; }
            public int DiscountPrice { get; set; }
        }

    }
}
