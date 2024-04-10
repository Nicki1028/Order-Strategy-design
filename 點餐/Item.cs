using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal class Item
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public string Total { get; set; }

        public string Note { get; set; }
        public Item(string name, string price, string count, string total, string note)
        {
            Name = name;
            Price = price;
            Count = count;
            Total = total;
            Note = note;
        }
    }

}
