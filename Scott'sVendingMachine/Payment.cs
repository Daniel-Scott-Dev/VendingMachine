using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class Payment
    {
        public double Money { get; set; }


        public double PaymentType(PaymentID id)
        {
            VendingMachine vendingMachine = new();  
            if (id == PaymentID.Vipps)
            {
                foreach (Confectionary item in vendingMachine. )
                {

                }
                Console.WriteLine($"Send  to Vipps Nr: 47661550");


                Money = amount;
            }
            else if (id == PaymentID.Cash)
            {
                Console.WriteLine($"Insert {amount} into machine slot");
                Money = amount;
            }

            return Money;
        }
    }
}
