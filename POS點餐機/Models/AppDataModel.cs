using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐機.Models
{
    internal class AppDataModel
    {
        public static MenuModel.Menu[] Menus { get; set; }
        public static MenuModel.Discount[] Discounts { get; set; }
        public static String MenuJson { get; set; }

        static AppDataModel()
        {

            string menuPath = ConfigurationManager.AppSettings["Menupath"];
            MenuJson = File.ReadAllText(menuPath);
            var menuModel = JsonConvert.DeserializeObject<MenuModel>(MenuJson);
            Discounts = menuModel.Discounts;
            Menus = menuModel.Menus;
        }
    }
}
