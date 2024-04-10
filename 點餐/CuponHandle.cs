using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal class CuponHandle
    {
        public List<Item> Itemlist
        { get; set; }
        public string Cupontext
        { get; set; }
       
        public Cupon ChoiceCupon(List<Item> itemlist, string cupontext)
        {
                Cupon cupon = null;
                switch (cupontext)
                {
                    case "雞排飯買二送一":
                        cupon = new Chickenbuytwo(itemlist, cupontext);
                        break;
                    case "全部品項打85折":
                        cupon = new Discount(itemlist, cupontext);
                        break;
                    case "排骨飯送紅茶":
                        cupon = new Porkgivetea(itemlist, cupontext);
                        break;
                    case "菜飯便當加點茶葉蛋10元":
                        cupon = new Vegetablewithegg(itemlist, cupontext);
                        break;
                    case "滿200折50":
                        cupon = new Totalgive(itemlist, cupontext);
                        break;
                }
                return cupon;                    
        }
        
    }
}

