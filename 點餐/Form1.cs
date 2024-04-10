using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace 點餐
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            // 雞腿飯 70
            // data[0] => 雞腿飯
            // data[1] => 70
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Orderdetail("品項", "單價", "數量", "小計", "備註");
            flowLayoutPanel5.ShowOrederdetail();
            total_lab.Text = flowLayoutPanel5.CalculateTotal();
        }


        private void Form1_Load(object sender, EventArgs e)
        {           
            string[] foods = {"雞排飯$80", "雞腿飯$70","控肉飯$75","排骨飯$65","菜飯$60" };
            foods.CreateMenu(flowLayoutPanel1, checkbox_checkedChange, numericupdown_valueChange);
                   
            string[] appetizer = { "茶葉蛋$15", "香腸$20", "烤茄子$25", "炸豆腐$30", "高麗菜$30" };
            appetizer.CreateMenu(flowLayoutPanel2, checkbox_checkedChange, numericupdown_valueChange);           
           
            string[] dessert = { "巧克力蛋糕$45", "甜甜圈$45", "草莓千層$50", "抹茶麻糬$50", "藍莓厚片$50" };
            dessert.CreateMenu(flowLayoutPanel3, checkbox_checkedChange, numericupdown_valueChange);

            string[] drink = { "紅茶$20", "綠茶$20", "奶茶$25", "烏龍拿鐵$50", "觀音拿鐵$50" };
            drink.CreateMenu(flowLayoutPanel4, checkbox_checkedChange, numericupdown_valueChange);
            
            flowLayoutPanel5.Orderdetail("品項", "單價", "數量", "小計","備註");                      
            comboBox1.Items.Add("滿200折50");
            comboBox1.Items.Add("雞排飯買二送一");
            comboBox1.Items.Add("排骨飯送紅茶");
            comboBox1.Items.Add("全部品項打85折");
            comboBox1.Items.Add("菜飯便當加點茶葉蛋10元");

        }

        private void checkbox_checkedChange(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            OrderHandler checkchange = new OrderHandler(comboBox1);
            checkchange.Check(checkBox, flowLayoutPanel5);
            total_lab.Text = flowLayoutPanel5.CalculateTotal();
        }

        private void numericupdown_valueChange(object sender, EventArgs e)
        {
            NumericUpDown count = (NumericUpDown)sender;
            OrderHandler checkchange = new OrderHandler(comboBox1);
            checkchange.Numeric(count, flowLayoutPanel5);
            total_lab.Text = flowLayoutPanel5.CalculateTotal();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.Text != "") 
            {
                Order.itemlist.ForEach(x => x.Note = "");
                Order.itemlist.RemoveAll(x => x.Total == "0" || String.IsNullOrWhiteSpace(x.Name));

                CuponHandle cuponHandle = new CuponHandle();
                Context context = new Context();
                cuponHandle.Itemlist = Order.itemlist;
                cuponHandle.Cupontext = comboBox1.Text;
                context.Strategyuse(cuponHandle.ChoiceCupon(Order.itemlist, comboBox1.Text));
                Order.Showonpanel(flowLayoutPanel5);
                total_lab.Text = flowLayoutPanel5.CalculateTotal();
            }
        }
    }
}
