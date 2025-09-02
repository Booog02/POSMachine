using Newtonsoft.Json;
using POS點餐機.Models;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using static POS點餐機.Models.MenuModel;

namespace POS點餐機
{


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EventCenter.ReceivedRenderPanel += RenderPanelHandler;
        }


        private void Form1_Load(object sender, EventArgs e)
        {


            //select:資料加工 => 一筆資料近來 一筆資料出去 資料只會因為select 加工而產生變化，不會減少原來資料筆數
            //where:資料篩選 => 一筆資料近來 不一定一筆資料就會出去，資料會因為 where 條件式的不同而減少資料筆數

            //List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };

            ////匿名類別寫法
            //var temp = nums.Select(x =>
            //{

            //    if (x % 2 == 0)
            //        return new { Id = x * 2, Name = "StudentName" };
            //    else
            //        return null;
            //}).ToList();


            //selectMany: 資料攤平

            //List<List<int>> numbers = new List<List<int>> { new List<int>() { 1, 2, 3 }, new List<int>() { 4, 5, 6 }, new List<int>() { 7, 8, 9 } };
            //List<int> nums = numbers.SelectMany(x => x).ToList();


            //GroupBy的目的是將指定的欄位的Key作為分組的依據
            //每一個組別都會是一個List(集合)
            //因為已經分組，所以只能使用 聚合函數進行計算 (Max,Min,Average,Sum,Count) 不能拿群組Key 以外的資料

            //var temp = menuModel.Menus
            //                    .GroupBy(x => x.Type)
            //                    .Select(x => new
            //                    {
            //                        Type = x.Key,
            //                        TotalPrice = x.Sum(y => y.Items.Sum(z => z.Price))
            //                    })
            //                    .Where(x => x.TotalPrice <= 300);



            //var temp = menuModel.Discounts.GroupBy(x => x.Strategy)
            //                              .Select(x => new
            //                              {
            //                                  Strategy = x.Key,
            //                                  Count = x.Count(),

            //                              });



            RenderMenuPanels(AppDataModel.Menus);


            comboBox1.DataSource = AppDataModel.Discounts;
            comboBox1.DisplayMember = "Name";

            Test1(x => TotalOddNum(x));



        }


        private void Test1(Func<int, int> func)
        {
            Debug.WriteLine(func.Invoke(10));
        }

        private int TotalOddNum(int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                if (i % 2 != 0)
                    sum += i;
            }

            return sum;

        }


        private int TotalEvenNum(int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                    sum += i;
            }

            return sum;

        }
        private int TotalNum(int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum += i;
            }

            return sum;

        }






        private void RenderMenuPanels(MenuModel.Menu[] menus)
        {

            flowLayoutPanel1.Controls.Clear();



            for (int i = 0; i < menus.Length; i++)
            {
                Menu menu = menus[i];




                FlowLayoutPanel categoryPanel = new FlowLayoutPanel();
                categoryPanel.Width = flowLayoutPanel1.Width / 2 - 20;
                categoryPanel.Height = flowLayoutPanel1.Height / 2 - 20;

                //分類餐點標籤
                Label categoryLabel = new Label();
                categoryLabel.AutoSize = false;
                categoryLabel.Text = $"{menu.Type}";
                categoryLabel.Width = categoryPanel.Width;
                categoryLabel.Height = 30;


                categoryPanel.Controls.Add(categoryLabel);



                //餐點項目
                for (int j = 0; j < menu.Items.Length; j++)
                {
                    Item item = menu.Items[j];
                    FlowLayoutPanel rowPanel = new FlowLayoutPanel();

                    rowPanel.Width = categoryPanel.Width;
                    rowPanel.AutoSize = true;
                    rowPanel.Padding = new Padding(0);
                    rowPanel.Margin = new Padding(0, 3, 0, 3);

                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = $"{item.Name.PadRight(5)} ${item.Price}";
                    checkBox.Tag = item;
                    checkBox.Width = (int)(categoryPanel.Width * 0.7);
                    checkBox.TextAlign = ContentAlignment.MiddleLeft;
                    checkBox.CheckedChanged += CheckBox_CheckChanged;


                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Width = (int)(categoryPanel.Width * 0.2);
                    numericUpDown.Minimum = 0;
                    numericUpDown.Maximum = 99;
                    numericUpDown.TextAlign = HorizontalAlignment.Center;
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged;




                    rowPanel.Controls.Add(checkBox);
                    rowPanel.Controls.Add(numericUpDown);
                    categoryPanel.Controls.Add(rowPanel);
                }
                flowLayoutPanel1.Controls.Add(categoryPanel);
            }
        }


        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown num = (NumericUpDown)checkBox.Parent.Controls[1];
            Debug.WriteLine(checkBox.Text);

            num.Value = checkBox.Checked ? 1 : 0;

            MenuItem item = new MenuItem(checkBox.Text, (int)num.Value);
            Order.AddOrder((MenuModel.Discount)comboBox1.SelectedValue, item);



        }
        private void RenderPanelHandler(object sender, RenderOrderModel renderOrder)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(renderOrder.Panel);
            label1.Text = renderOrder.TotalAmount;


        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox check = (CheckBox)numericUpDown.Parent.Controls[0];
            Debug.WriteLine(numericUpDown.Value.ToString());

            check.Checked = numericUpDown.Value > 0;

            MenuItem item = new MenuItem(check.Text, (int)numericUpDown.Value);

            Order.AddOrder((MenuModel.Discount)comboBox1.SelectedValue, item);



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is MenuModel.Discount discountType)
            {
                Order.ChangeDiscountType(discountType);
            }
        }
    }
}
