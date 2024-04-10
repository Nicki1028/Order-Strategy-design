using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    internal class Porkgivetea:Cupon
    {
        public Porkgivetea(List<Item> Itemlist, string Cupontext) : base(Itemlist, Cupontext)
        {

        }
        public override List<Item> Cuponuse()
        {
            if (Cupontext == "排骨飯送紅茶")
            {
                Item findpork = Itemlist.FirstOrDefault(x => x.Name == "排骨飯");
                if (findpork != null)
                {
                    Item newitem = new Item("紅茶", "20", findpork.Count, "0", Cupontext);
                    Itemlist.Add(newitem);
                }
                return Itemlist;
            }
            return Itemlist;
        }
    }
}
