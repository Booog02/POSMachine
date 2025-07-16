using System;
using System.ComponentModel;
using System.Diagnostics;

namespace POS點餐機
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EventCenter.ReceivedRenderPanel += RenderPanelHandler;
        }
        //動態生成
        string[] mainFoods = { "雞腿飯 $90" , "雞排飯 $95" ,
                               "排骨飯 $85" , "豬排飯 $75" };

        string[] sideFoods = { "燙青菜 $40", "滷肉飯 $30", "蛋花湯 $20", "滷蛋 $10" };

        string[] drinks = { "紅茶 $15", "綠茶 $20", "奶茶 $25" };

        string[] desserts = { "布丁 $35", "起司蛋糕 $40" };

        private void Form1_Load(object sender, EventArgs e)
        {

            //建立checkbox
            #region 0618擴充前寫法
            //for (int i = 0; i < mainFoods.Length; i++)
            //{
            //    FlowLayoutPanel container = new FlowLayoutPanel();
            //    container.Width = flowLayoutPanel1.Width;
            //    container.Height = 40;
            //    CheckBox check = new CheckBox();
            //    check.Text = mainFoods[i];
            //    check.Size = new Size(100, 30);

            //    //數量控制器
            //    NumericUpDown num = new NumericUpDown();
            //    num.Value = 0;
            //    num.Width = 80;
            //    check.Tag = num;


            //    container.Controls.Add(check);
            //    container.Controls.Add(num);

            //    flowLayoutPanel1.Controls.Add(container);


            //}

            //for (int i = 0; i < sideFoods.Length; i++)
            //{
            //    FlowLayoutPanel container2 = new FlowLayoutPanel();
            //    container2.Width = flowLayoutPanel2.Width;
            //    container2.Height = 40;
            //    CheckBox check = new CheckBox();
            //    check.Text = sideFoods[i];
            //    check.Size = new Size(100, 30);

            //    NumericUpDown num = new NumericUpDown();
            //    num.Value = 0;
            //    num.Width = 80;
            //    check.Tag = num;

            //    container2.Controls.Add(check);
            //    container2.Controls.Add(num);

            //    flowLayoutPanel2.Controls.Add(container2);
            //}

            //for (int i = 0; i < drinks.Length; i++)
            //{

            //    FlowLayoutPanel container3 = new FlowLayoutPanel();
            //    container3.Width = flowLayoutPanel3.Width;
            //    container3.Height = 40;
            //    CheckBox check = new CheckBox();
            //    check.Text = drinks[i];
            //    check.Size = new Size(100, 30);

            //    NumericUpDown num = new NumericUpDown();
            //    num.Value = 0;
            //    num.Width = 80;
            //    check.Tag = num;

            //    container3.Controls.Add(check);
            //    container3.Controls.Add(num);

            //    flowLayoutPanel3.Controls.Add(container3);
            //}

            //for (int i = 0; i < desserts.Length; i++)
            //{
            //    FlowLayoutPanel container4 = new FlowLayoutPanel();
            //    container4.Width = flowLayoutPanel4.Width;
            //    container4.Height = 40;
            //    CheckBox check = new CheckBox();
            //    check.Text = desserts[i];
            //    check.Size = new Size(100, 30);

            //    NumericUpDown num = new NumericUpDown();
            //    num.Value = 0;
            //    num.Width = 80;
            //    check.Tag = num;

            //    container4.Controls.Add(check);
            //    container4.Controls.Add(num);

            //    flowLayoutPanel4.Controls.Add(container4);
            //}
            #endregion

            flowLayoutPanel1.AddFoodMenu(mainFoods, CheckBox_CheckChanged, NumericUpDown_ValueChanged);
            flowLayoutPanel2.AddFoodMenu(sideFoods, CheckBox_CheckChanged, NumericUpDown_ValueChanged);
            flowLayoutPanel3.AddFoodMenu(drinks, CheckBox_CheckChanged, NumericUpDown_ValueChanged);
            flowLayoutPanel4.AddFoodMenu(desserts, CheckBox_CheckChanged, NumericUpDown_ValueChanged);

            comboBox1.SelectedIndex = 0;
        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown num = (NumericUpDown)checkBox.Parent.Controls[1];
            Debug.WriteLine(checkBox.Text);

            num.Value = checkBox.Checked ? 1 : 0;

            MenuItem item = new MenuItem(checkBox.Text, (int)num.Value);
            Order.AddOrder(comboBox1.Text, item);



        }
        private void RenderPanelHandler(object sender, RenderOrder renderOrder)
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

            Order.AddOrder(comboBox1.Text, item);



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.ChangeDiscountType(comboBox1.Text);
        }
    }
}
