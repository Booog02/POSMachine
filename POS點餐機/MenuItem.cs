using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public MenuItem(string foodText)
        {
            string[] parts = foodText.Split('$');
            Name = parts[0].Trim();
            Price = int.Parse(parts[1].Trim());

        }

    }
}
