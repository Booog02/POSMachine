using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace POS點餐機
{
    internal static class Extensions
    {
        #region 0618 作業寫法
        //public static int GetPrice(this CheckBox checkbox)
        //{
        //    string[] parts = checkbox.Text.Split('$');


        //    if (int.TryParse(parts[1].Trim(), out int price))
        //    {
        //        return price;
        //    }
        //    return 0;

        //}

        //public static int GetAmount(this CheckBox checkbox)
        //{
        //    if (checkbox.Tag is NumericUpDown num)
        //    {
        //        return (int)num.Value;
        //    }
        //    return 0;
        //}
        #endregion

        public static void AddFoodMenu(this FlowLayoutPanel OptionPanel, string[] options, EventHandler CheckedChanged, EventHandler ValueChanged)
        {
            for (int i = 0; i < options.Length; i++)
            {
                FlowLayoutPanel container = new FlowLayoutPanel();
                container.Width = OptionPanel.Width;
                container.Height = 40;
                CheckBox check = new CheckBox();
                check.Text = options[i];
                check.Size = new Size(100, 30);
                check.CheckedChanged += CheckedChanged;


                //數量控制器
                NumericUpDown num = new NumericUpDown();
                num.Value = 0;
                num.Width = 80;
                num.ValueChanged += ValueChanged;
                check.Tag = num;
                num.Tag = check;


                container.Controls.Add(check);
                container.Controls.Add(num);

                OptionPanel.Controls.Add(container);

            }
        }

        #region 擴充在 FlowLayoutPanel

        public static int CalculateTotal(this FlowLayoutPanel panel)
        {
            int total = 0;

            for (int j = 0; j < panel.Controls.Count; j++)
            {
                FlowLayoutPanel itemPanel = (FlowLayoutPanel)panel.Controls[j];

                CheckBox check = (CheckBox)itemPanel.Controls[0];


                if (check != null && check.Checked)
                {
                    #region 0618擴充方法前
                    string[] parts = check.Text.Split('$');

                    int price = int.Parse(parts[1].Trim());

                    NumericUpDown num = (NumericUpDown)check.Tag;
                    int amount = (int)num.Value;

                    total += price * amount;
                    #endregion

                }
            }
            return total;


        }
        #endregion

        #region 0625HW 動態生成選品預覽

        public static void UpdatePreview(this FlowLayoutPanel categoryPanel, FlowLayoutPanel previewPanel)
        {

            for (int j = 0; j < categoryPanel.Controls.Count; j++)
            {
                FlowLayoutPanel itemPanel = (FlowLayoutPanel)categoryPanel.Controls[j];

                CheckBox check = (CheckBox)itemPanel.Controls[0];


                string[] parts = check.Text.Split('$');
                string FoodName = parts[0].Trim();
                int price = int.Parse(parts[1].Trim());
                NumericUpDown num = (NumericUpDown)check.Tag;
                int amount = (int)num.Value;
                int Note = price * amount;

                if (check != null && check.Checked && amount > 0)
                {
                    #region 預覽區生成前
                    //if (check != null && check.Checked)
                    //{
                    //    #region 0618擴充方法前
                    //    string[] parts = check.Text.Split('$');


                    //    NumericUpDown num = (NumericUpDown)check.Tag;
                    //    int amount = (int)num.Value;

                    //    total += price * amount;
                    //    #endregion

                    //}
                    #endregion

                    FlowLayoutPanel previewChoices = new FlowLayoutPanel
                    {
                        AutoSize = true,
                    };

                    previewChoices.Controls.Add(CreateLable(FoodName, 100));
                    previewChoices.Controls.Add(CreateLable(price.ToString(), 50));
                    previewChoices.Controls.Add(CreateLable(amount.ToString(), 50));
                    previewChoices.Controls.Add(CreateLable(Note.ToString(), 100));
                    previewPanel.Controls.Add(previewChoices);

                }


            }

        }

        private static Label CreateLable(string Text, int width)
        {
            return new Label
            {
                Text = Text,
                Width = width
            };
        }

        #endregion

    }
}

