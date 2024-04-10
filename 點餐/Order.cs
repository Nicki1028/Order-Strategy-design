using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    internal static class Order
    {
        public static List<Item> itemlist = new List<Item>();
        public static void Additem(Item item, ComboBox comboBox)
        {
            itemlist.RemoveAll(x => !String.IsNullOrWhiteSpace(x.Note));
            Item findItem = itemlist.FirstOrDefault(x => x.Name == item.Name);
            if (findItem == null)
            {
                itemlist.Add(item);
            }
            else
            {
                findItem.Count = item.Count;
                findItem.Total = (int.Parse(item.Price) * int.Parse(item.Count)).ToString();

                if (item.Count == "0")
                {
                    itemlist.Remove(findItem);
                }
            }            
            CuponHandle cuponHandle = new CuponHandle();
            Context context = new Context();
            cuponHandle.Itemlist = itemlist;
            cuponHandle.Cupontext = comboBox.Text;
            context.Strategyuse(cuponHandle.ChoiceCupon(itemlist, comboBox.Text));           
        }
        public static void Removeitem(Item item)
        {
            Item finditem = itemlist.FirstOrDefault(x => x.Name == item.Name);
            itemlist.Remove(finditem);
        }
        public static void Showonpanel(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            panel.AddMenutitle();
            foreach (Item item in itemlist)
            {
                panel.Orderdetail(item.Name, item.Price, item.Count, item.Total, item.Note);
            }
        }
    }
}
