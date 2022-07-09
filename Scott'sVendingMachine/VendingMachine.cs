using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott_sVendingMachine
{
    public class VendingMachine
    {

        //TODO
        //Legge til insert money meny valg fra start.
        //lage en CLass for alle CW meldinger
        //show inventory menu choise
        //change List til Dictionary
        public Dictionary<Confectionary> Inventory {get; private set;} = new();
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

                            string productName = ProductName();
                            Console.WriteLine($"Giving out {productName}");
                            payment.Money -= GettingProductPrice(productChoise);


                            if (payment.Money > 0)
                            {
                                payment.ReturningChange();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{productChoise} is out of stock, please choose another inventoryItem.");
                        }
                        break;
                    case '2':
                        payment.ReturningChange();
                        break;
                    case '3':
                        keeprunning = false;
                        break;
                }

            }

        }
        //have to change Inventory List to Dictionary to have the ID of product work!
        private string ProductName(char productChoise)
        {
            string productName = "";
            foreach (Confectionary inventoryItem in Inventory)
            {
                if (inventoryItem.Name == productChoise)
                {
                    productName = inventoryItem.Name;
                }
                
            }
            return productName;
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
            Console.WriteLine("1: Choose inventoryItem");
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

        public int GettingProductPrice(char productChoise)
        {
            int productPrice = 0;
            foreach (Confectionary inventoryItem in Inventory)
            {
                if (productChoise == inventoryItem.ProductID)
                {
                    productPrice = inventoryItem.Price;
                }
            }
            return productPrice;
        }

        public List<Confectionary> GetList()
        {
            return Inventory;
        }
    }
}
