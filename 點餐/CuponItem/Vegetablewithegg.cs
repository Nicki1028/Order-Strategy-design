using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace 點餐
{
    internal class Vegetablewithegg:Cupon
    {
        public Vegetablewithegg(List<Item> Itemlist, string Cupontext) : base(Itemlist, Cupontext)
        {

        }
        public override List<Item> Cuponuse()
        {
            if (Cupontext == "菜飯便當加點茶葉蛋10元")
            {
                Item findvegetable = Itemlist.FirstOrDefault(x => x.Name == "菜飯");
                Item findegg = Itemlist.FirstOrDefault(x => x.Name == "茶葉蛋");
                if (findvegetable != null && findegg != null)
                {
                    findegg.Price = "10";
                    findegg.Total = (int.Parse(findegg.Price) * int.Parse(findegg.Count)).ToString();
                    findegg.Note = Cupontext;
                }
                return Itemlist;
            }
            return Itemlist;
        }
    }
}
