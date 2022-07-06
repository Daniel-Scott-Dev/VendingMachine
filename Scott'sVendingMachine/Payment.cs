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


        public void PaymentType(char paymentChoise, char productChoise)
        {
            VendingMachine vendingMachine = new();
            
            int productPrice = 0;
            if (paymentChoise == 1)
            {
                ///Getting product price
                foreach (Confectionary item in vendingMachine.inventory)
                {
                    if (productChoise == item.ProductID)
                    {
                        productPrice = item.Price;
                    }
                }
                Console.WriteLine($"Send {productPrice}$ to Vipps number: 47661550");
                
                /// Asuming payment is made to vending machine via Vipps
                Money += Convert.ToDouble(productPrice);
            }
            else if (paymentChoise == 2 && Money < productPrice)
            {
                Console.WriteLine($"Insert {(Money - productPrice)}$ or more into machine slot:");
                /// Asuming payment is made with coins or notes
                double moneyReceived = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"{moneyReceived}$ received");
                Money += moneyReceived;
            }

            //make this method void and add a menu option of adding money upront?
        }

        public void GivesMoneyBack()
        {
            if (Money > 0)
            {
                Console.WriteLine($"{Money}$ payed out..");
                Money = 0;
            }
            else
            {
                Console.WriteLine($"No funds to pay out. Current balance: {Money}$");
            }
        }
    }
}
