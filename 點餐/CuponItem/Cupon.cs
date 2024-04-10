using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal abstract class Cupon
    {
        public string Cupontext;
        public static List<Item> Itemlist = new List<Item>();
        protected Cupon(List<Item> itemlist, string cupontext)
        {
            Itemlist = itemlist;
            Cupontext = cupontext;
        }
        public abstract List<Item> Cuponuse();
    }
}
