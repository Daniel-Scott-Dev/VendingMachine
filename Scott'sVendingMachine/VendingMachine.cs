using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class VendingMachine
    {
        public List<Confectionary> inventory {get; set;} = new()
        {
            new Confectionary(1, "Snickers", 5, 25),
            new Confectionary(2, "Kitkat", 5, 20),
            new Confectionary(3, "Milkyway", 5, 30),
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
                        if (CheckInventory(Convert.ToInt32(productChoise)) == true)
                        {
                            Console.WriteLine($"\nplease choose payment type:\n1: {PaymentID.Vipps}\n2: {PaymentID.Cash}");
                            char paymentChoise = Console.ReadKey().KeyChar;

                            payment.PaymentType(paymentChoise, productChoise);

                            Console.WriteLine("Payment complete");
                            Console.WriteLine($"Giving out {productChoise}");
                            if (payment.Money > 0)
                            {
                                Console.WriteLine($"Paying out {payment.Money} in change");
                                payment.Money = 0;
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

        private bool CheckInventory(int productChoise)
        {
            bool inventoryResult = true;
            foreach (Confectionary item in inventory)
            {
                if (item.ProductID == productChoise && item.Stock > 0)
                {
                    inventoryResult = true;
                }
                else if (item.ProductID == productChoise && item.Stock == 0)
                {
                    inventoryResult = false;
                }
            }
            return inventoryResult;
        }

        private void MainMenu()
        {
            Console.WriteLine("\n\nWelcome! Please choose a option below:");
            Console.WriteLine("1: Choose product");
            Console.WriteLine("2: Gives money back");
            Console.WriteLine("3: Exit");
            Console.WriteLine("-------");
            Console.WriteLine($"Inserted money: {payment.Money}");
            Console.WriteLine("-------\n\n");

                            
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

        
    }
}
