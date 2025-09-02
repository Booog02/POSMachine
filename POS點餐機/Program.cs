using POS點餐機.Models;
using System.Collections.Generic;

namespace POS點餐機
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            //任選主餐 + 任選飲料 = 150
            //紅茶15
            //奶茶25
            //紅茶買3杯 奶茶買1杯 珍珠奶茶55買1杯 芒果冰沙70買1杯  雞腿飯買六個

            //紅茶 紅茶 紅茶 奶茶 奶茶 珍珠奶茶 芒果冰沙


            List<MenuItem> drinks = new List<MenuItem>()
            {
                new MenuItem("芒果冰沙$70",1),
                new MenuItem("紅茶$15",3),
                new MenuItem("珍珠奶茶$55",1),
                new MenuItem("奶茶$25",2),
            };
            //15+15+15+25+25+55+70

            List<MenuItem> foods = new List<MenuItem>()
            {
                new MenuItem("排骨飯$85",2),
                new MenuItem("雞腿飯$90",2),
                new MenuItem("豬排飯$75",2),
                new MenuItem("雞排飯$95",2),
            };
            // 75+75+85+85+90+90+95
            int times = 7;

            List<List<MenuItem>> items = new List<List<MenuItem>>();
            items.Add(foods);
            items.Add(drinks);

            var temp1 = items.SelectMany(x => x);



            //Enumerable.Repect 可以根據指定數量將每一筆資料重複n次
            var temp = items.Select(item =>
            {
                var allProducts = item.SelectMany(x =>
                {
                    var products = Enumerable.Repeat(x, x.Amount);
                    return products;
                });

                var takProducts = allProducts.OrderBy(x => x.Price).Take(times);
                int total = takProducts.Sum(x => x.Price);

                return total;
            }).ToList();
            int price = temp.Sum(x => x);







            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}