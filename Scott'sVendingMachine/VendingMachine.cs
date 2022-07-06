using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class VendingMachine
    {
        List<Confectionary> inventory {get; set;} = new()
        {
            new Confectionary("Snickers", 5, 25),
            new Confectionary("Kitkat", 5, 20),
            new Confectionary("Milkyway", 5, 30),
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
                        if (productChoise == '1' && CheckInventory(Convert.ToString(productChoise)) == true)
                        {
                            Console.WriteLine($"please choose payment type: 1: {PaymentID.Cash}\n2: {PaymentID.Vipps}");
                            char paymentChoise = Console.ReadKey().KeyChar;
                            payment.PaymentType(paymentChoise);
                        }
                        break;
                    case '2':
                        GivesMoneyBack();
                        break;
                    case '3':
                        keeprunning = false;
                        break;
                }

            }



        }

        private bool CheckInventory(string productChoise)
        {
            bool inventoryResult = true;
            foreach (Confectionary item in inventory)
            {
                if (item.Name == productChoise && item.Nr > 0)
                {
                    inventoryResult = true;
                }
                else if (item.Name == productChoise && item.Nr == 0)
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
            Console.WriteLine("1: Snickers");
            Console.WriteLine("2: Kitkat");
            Console.WriteLine("3: Milkyway");
        }

        public void GivesMoneyBack()
        {
            if (payment.Money > 0)
            {
                Console.WriteLine($"{payment.Money} payed out..");
                payment.Money = 0;
            }
            else
            {
                Console.WriteLine($"No funds to pay out. Current balance: {payment.Money}");
            }
        }
    }
}
