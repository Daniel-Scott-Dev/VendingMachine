using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class Confectionary
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public Confectionary(int productID, string name, int stock, int price)
        {
            ProductID = productID;
            Name = name;
            Stock = stock;
            Price = price;
        }
    }
}
