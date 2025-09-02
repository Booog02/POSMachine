namespace POS點餐機
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboBox1 = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(921, 696);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoScroll = true;
            flowLayoutPanel5.Location = new Point(610, 48);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(404, 622);
            flowLayoutPanel5.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold);
            label6.Location = new Point(610, 25);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 0;
            label6.Text = "品名";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold);
            label7.Location = new Point(706, 25);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 0;
            label7.Text = "單價";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold);
            label8.Location = new Point(772, 25);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 0;
            label8.Text = "數量";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold);
            label9.Location = new Point(830, 25);
            label9.Name = "label9";
            label9.Size = new Size(41, 20);
            label9.TabIndex = 0;
            label9.Text = "小計";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "雞腿飯買二送一", "雞排飯買三個打85折", "排骨飯搭配燙青菜120元", "豬排飯三份210元", "雞腿飯搭配燙青菜送紅茶一杯", "雞排飯買兩份搭配兩杯紅茶打95折", "飲料任選三杯40元", "飲料任選5杯打8折_用最低價", "豬排飯兩份搭配蛋花湯一份就送布丁一份紅茶一份", "全品項購買滿399打8折", "全品項不限金額打9折" });
            comboBox1.Location = new Point(610, 696);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(271, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(30, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(498, 677);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 763);
            Controls.Add(comboBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
