using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    public static class Extension
    {
        public static void CreateMenu(this string[] foods, FlowLayoutPanel panel,EventHandler checkboxCheckChange,EventHandler valueChange)
        {
            foreach (string food in foods)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.CheckedChanged += checkboxCheckChange;
                NumericUpDown count = new NumericUpDown();
                count.ValueChanged += valueChange;
                FlowLayoutPanel group = new FlowLayoutPanel();
                checkBox.Tag = count;
                count.Tag = checkBox;
                group.Width = 300;
                group.Height = 40;
                checkBox.Text = food;
                group.Controls.Add(checkBox);
                group.Controls.Add(count);
                panel.Controls.Add(group);            
            }
        }
        public static string CalculateTotal(this FlowLayoutPanel panel)
        {
            
            int total = 0;
            foreach (Item i in Order.itemlist)
            {
                total += int.Parse(i.Total);
            }      
            //foreach (FlowLayoutPanel i in panel.Controls)
            //{
            //    CheckBox check = (CheckBox)i.Controls[0];
            //    NumericUpDown count = (NumericUpDown)i.Controls[1];

            //    if (check.Checked)
            //    {
            //        string[] data = check.Text.Split('$');
            //        total += int.Parse(data[1]) * (int)count.Value;
            //    }
            //}
            return total.ToString();
        }

        public static void AddMenutitle(this FlowLayoutPanel panel)
        {
            Label label = new Label();           
            Label label1 = new Label();           
            Label label2 = new Label();         
            Label label3 = new Label();
            Label label4 = new Label();
            
            FlowLayoutPanel panel1 = new FlowLayoutPanel();
            panel1.Height = 50;
            panel1.Width = panel.Width;
            if (panel.Controls.Count == 0)
            {
                label.Text = "品項";
                panel1.Controls.Add(label);
                label1.Text = "單價";
                panel1.Controls.Add(label1);
                label2.Text = "數量";
                panel1.Controls.Add(label2);
                label3.Text = "小計";
                panel1.Controls.Add(label3);
                label4.Text = "備註";
                panel1.Controls.Add(label4);
                panel.Controls.Add(panel1);
            }
        }
        public static void Orderdetail(this FlowLayoutPanel panel,string item, string price, string count, string total, string note)
        {
            
            Label label = new Label();
            label.Text = item;
            Label label1 = new Label();
            label1.Text = price;
            Label label2 = new Label();
            label2.Text = count;
            Label label3 = new Label();
            label3.Text = total;
            Label label4 = new Label();
            label4.Text = note;
            FlowLayoutPanel panel1 = new FlowLayoutPanel();
               
            panel1.Height = 50;
            panel1.Width = panel.Width;
            panel1.Controls.Add(label);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel.Controls.Add(panel1);       
        }
        
        public static void ShowOrederdetail(this FlowLayoutPanel panel)
        {
            
            foreach (Item item in Order.itemlist)
            {
                panel.Orderdetail(item.Name,item.Price, item.Count, item.Total, item.Note);
            }
            //int total = 0;         
            //foreach (FlowLayoutPanel i in panel1.Controls)
            //{             
            //    CheckBox check = (CheckBox)i.Controls[0];
            //    NumericUpDown count = (NumericUpDown)i.Controls[1];
            //    if (check.Checked)
            //    {                  
            //        string[] data = check.Text.Split('$');               
            //        total += int.Parse(data[1]) * (int)count.Value;
            //        panel.Adddetail(data[0], data[1], count.Value.ToString(), total.ToString(), null);
            //    }
            //}
            

        }

    }
}
