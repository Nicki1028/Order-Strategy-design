using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal class Discount : Cupon
    {
        public Discount(List<Item> Itemlist, string Cupontext) : base(Itemlist, Cupontext)
        {

        }
        public override List<Item> Cuponuse()
        {
            if (Cupontext == "全部品項打85折")
            {
                foreach (Item items in Itemlist)
                {
                    items.Note = Cupontext;
                    items.Total = ((int)((int.Parse(items.Price) * int.Parse(items.Count) * 0.85))).ToString();
                }
                return Itemlist;
            }
            return Itemlist;
        }
    }
}
