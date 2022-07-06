using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class Confectionary
    {
        public string Name { get; set; }
        public int Nr { get; set; }
        public int Price { get; set; }

        public Confectionary(string name, int nr, int price)
        {
            Name = name;
            Nr = nr;
            Price = price;
        }
    }
}
