using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    internal class Chickenbuytwo : Cupon
    {
        public Chickenbuytwo(List<Item> Itemlist, string Cupontext) : base(Itemlist, Cupontext)
        {

        }
        public override List<Item> Cuponuse()
        {
            if (Cupontext == "雞排飯買二送一")
            {
                Item findchicken = Itemlist.FirstOrDefault(x => x.Name == "雞排飯");
                if (findchicken != null)
                {
                    if (int.Parse(findchicken.Count) % 2 == 0)
                    {
                        string buy = (int.Parse(findchicken.Count) / 2).ToString();
                        Item newitem = new Item("雞排飯", "80", buy, "0", Cupontext);
                        Itemlist.Add(newitem);
                    }
                }
                return Itemlist;
            }
            return Itemlist;
        }
    }
}
