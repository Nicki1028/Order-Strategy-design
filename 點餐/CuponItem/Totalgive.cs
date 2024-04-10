using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    internal class Totalgive : Cupon
    {
        public Totalgive(List<Item> Itemlist, string Cupontext) : base(Itemlist, Cupontext)
        {

        }
        public override List<Item> Cuponuse()
        {
            if (!Itemlist.Any(x => x.Note == "滿200折50"))
            {
                int totalprice = 0;
                foreach (Item i in Itemlist)
                {
                    totalprice += int.Parse(i.Total);
                }
                if (totalprice >= 200)
                {
                    Item newitem = new Item(" ", " ", " ", "-50", "滿200折50");
                    Itemlist.Add(newitem);
                }
            }                   
            return Itemlist;         
        }
    }
}
