using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class VendingMachine
    {
        public List<Confectionary> Inventory {get; private set;} = new()
        {
            new Confectionary('1', "Snickers", 5, 25),
            new Confectionary('2', "Kitkat", 5, 20),
            new Confectionary('3', "Milkyway", 5, 30),
        };

        
        Payment payment = new();

        public void Start()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                MainMenu();
                char userInput = Console.ReadKey().KeyChar;
                switch (userInput)
                {
                    case '1':
                        ChooseProduct();
                        char productChoise = Console.ReadKey().KeyChar;
                        if (CheckInventory(productChoise) == true)
                        {
                            Console.WriteLine($"\nplease choose payment type:\n1: {PaymentID.Vipps}\n2: {PaymentID.Cash}\n");
                            char paymentChoise = Console.ReadKey().KeyChar;

                            payment.MakingPayment(paymentChoise, productChoise);

                            if (paymentChoise == 1)
                            {
                                Console.WriteLine($"\nPayment with {PaymentID.Vipps} complete");
                            }
                            else
                            {
                                Console.WriteLine($"\nPayment with {PaymentID.Cash} complete");
                            }

                            Console.WriteLine($"Giving out {productChoise}");


                            if (payment.Money > 0)
                            {
                                payment.GivesMoneyBack();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{productChoise} is out of stock, please choose another product.");
                        }
                        break;
                    case '2':
                        payment.GivesMoneyBack();
                        break;
                    case '3':
                        keeprunning = false;
                        break;
                }

            }

        }

        private bool CheckInventory(char productChoise)
        {
            bool inventoryResult = false;
            foreach (Confectionary product in Inventory)
            {
                if (product.ProductID == productChoise && product.Stock > 0)
                {
                    inventoryResult = true;
                    return inventoryResult;
                }
                else if (product.ProductID == productChoise && product.Stock == 0)
                {
                    inventoryResult = false;
                }
            }
            return inventoryResult;
        }

        private void MainMenu()
        {
            Console.WriteLine("\nWelcome! Please choose a option below:");
            Console.WriteLine("1: Choose product");
            Console.WriteLine("2: Gives money back");
            Console.WriteLine("3: Exit");
            Console.WriteLine("-------");
            Console.WriteLine($"Inserted money: {payment.Money}");
            Console.WriteLine("-------\n\n");
            Console.Write("\n> ");

                            
                //Console.WriteLine("\n\nAvailable commands:");
                //Console.WriteLine("insert (money) - Money put into money slot");
                //Console.WriteLine("order (snickers, kitkat, milkyway) - Order from machines buttons");
                //Console.WriteLine("sms order (snickers, kitkat, milkyway) - Order sent by sms");
                //Console.WriteLine("recall - gives money back");
                //Console.WriteLine("-------");
                //Console.WriteLine("Inserted money: " + money);
                //Console.WriteLine("-------\n\n");
        }

        public void ChooseProduct()
        {
            Console.WriteLine("\n1: Snickers");
            Console.WriteLine("2: Kitkat");
            Console.WriteLine("3: Milkyway");
            Console.Write("\n> ");
        }

        public List<Confectionary> GetList()
        {
            return Inventory;
        }
    }
}
