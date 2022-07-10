namespace Scott_sVendingMachine
{
    public class VendingMachine
    {

        //TODO
        //Legge til insert money meny valg fra start.
        //lage en CLass for alle CW meldinger
        //show inventory menu choise
        //Add WriteLine Animation with thread.sleep when giving out product.
        public Dictionary<char, Confectionary> Inventory { get; set; } = new()
        {
            {'1', new Confectionary( "Snickers", 2, 25) },
            {'2', new Confectionary( "Kitkat", 2, 35) },
            {'3', new Confectionary( "Milkyway",3, 30) },
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
                        Console.Clear();
                        Console.WriteLine(ChooseProduct());
                        char productChoise = Console.ReadKey().KeyChar;
                        Console.Clear();
                        if (CheckInventory(productChoise) == true)
                        {
                            Console.WriteLine($"\nplease choose payment type:\n1: {PaymentID.Vipps}\n2: {PaymentID.Cash}\n");
                            char paymentChoise = Console.ReadKey().KeyChar;
                            Console.Clear();

                            payment.MakingPayment(paymentChoise, productChoise);

                            string productName = ProductName(productChoise);
                            Console.Beep();
                            Console.WriteLine($"\n||--Giving out {productName}--||\n");
                            payment.Money -= GettingProductPrice(productChoise);

                        }
                        else
                        {
                            Console.WriteLine($"\n{ProductName(productChoise)} is out of stock, please choose another product.");
                        }
                        break;
                    case '2':
                        payment.ReturningChange();
                        Console.Beep();
                        Thread.Sleep(3000);
                        break;
                    case '3':
                        keeprunning = false;
                        break;
                }
                Thread.Sleep(3000);
            }

        }
        private string ProductName(char productChoise)
        {
            string productName = "";
            foreach (KeyValuePair<char, Confectionary> inventoryItem in Inventory)
            {
                if (inventoryItem.Key == productChoise)
                {
                    productName = inventoryItem.Value.Name;
                }

            }
            return productName;
        }

        private bool CheckInventory(char productChoise)
        {
            bool inventoryResult = false;
            foreach (KeyValuePair<char, Confectionary> product in Inventory)
            {
                if (product.Key == productChoise && product.Value.Stock > 0)
                {
                    inventoryResult = true;
                    return inventoryResult;
                }
                else if (product.Key == productChoise && product.Value.Stock == 0)
                {
                    inventoryResult = false;
                }
            }
            return inventoryResult;
        }

        private void MainMenu()
        {
            Random random = new();

            bool runLoop = true;
            int loopCounter = 10;
            while (runLoop)
            {
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)random.Next(1, 16);
                Console.WriteLine("\n   --WELCOME--\n");
                Console.ResetColor();
                Thread.Sleep(90);
                loopCounter -= 1;
                if (loopCounter == 0)
                {
                    runLoop = false;
                }
            }

            Console.WriteLine("Please choose an option below:");
            Console.WriteLine("1: Choose product");
            Console.WriteLine("2: Give money back");
            Console.WriteLine("3: Exit");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Inserted money: {payment.Money} |");
            Console.WriteLine("-------------------\n");
            Console.Write("> ");


            //Console.WriteLine("\n\nAvailable commands:");
            //Console.WriteLine("insert (money) - Money put into money slot");
            //Console.WriteLine("order (snickers, kitkat, milkyway) - Order from machines buttons");
            //Console.WriteLine("sms order (snickers, kitkat, milkyway) - Order sent by sms");
            //Console.WriteLine("recall - gives money back");
            //Console.WriteLine("-------");
            //Console.WriteLine("Inserted money: " + money);
            //Console.WriteLine("-------\n\n");
        }

        public string ChooseProduct()
        {
            string products = "";
            foreach (KeyValuePair<char, Confectionary> item in Inventory)
            {
                products += $"\n{item.Key}: --{item.Value.Name}-- [Price: {item.Value.Price}$]";
            }
            return products;
        }

        public int GettingProductPrice(char productChoise)
        {
            int productPrice = 0;
            foreach (KeyValuePair<char, Confectionary> inventoryItem in Inventory)
            {
                if (productChoise == inventoryItem.Key)
                {
                    productPrice = inventoryItem.Value.Price;
                }
            }
            return productPrice;
        }
    }
}
