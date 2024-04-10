using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    internal class OrderHandler
    {   
        ComboBox combobox = new ComboBox();
        public OrderHandler(ComboBox comboBox) 
        {
            this.combobox = comboBox;
        }
        public void Check(CheckBox checkBox, FlowLayoutPanel panel)
        {   
            
            NumericUpDown count = (NumericUpDown)checkBox.Tag;
            string[] data = checkBox.Text.Split('$');
            int total = int.Parse(data[1]) * (int)count.Value;
            Item item = new Item(data[0], data[1], count.Value.ToString(), total.ToString(), null);
            
           
            if (checkBox.Checked)
            {
                count.Value = 1;
                item.Count = "1";

                Order.Additem(item, this.combobox);
                Order.Showonpanel(panel);
            }
            else
            {
                count.Value = 0;
                Order.Removeitem(item);
                Order.Showonpanel(panel);
            }
        }

        public void Numeric(NumericUpDown count, FlowLayoutPanel panel)
        {
            //FlowLayoutPanel panel = (FlowLayoutPanel)count.Parent;
            CheckBox check = (CheckBox)count.Tag;
            string[] data = check.Text.Split('$');
            int total = int.Parse(data[1]) * (int)count.Value;
            Item item = new Item(data[0], data[1], count.Value.ToString(), total.ToString(), null);

            if (count.Value == 1)
            {
                check.Checked = true;
                Order.Additem(item, this.combobox);
                Order.Showonpanel(panel);
            }
            else if (count.Value == 0)
            {
                check.Checked = false;
            }
            else
            {
                Order.Additem(item, this.combobox);
                Order.Showonpanel(panel);
            }
        }
    }
}
