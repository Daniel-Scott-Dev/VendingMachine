namespace Scott_sVendingMachine
{
    public class Payment
    {
        public double Money { get; set; }
        //TODO:

        public void MakingPayment(char paymentChoise, char productChoise, Dictionary<char, Confectionary> Inventory)
        {   
            //finding product price
            int productPrice = GettingProductPrice(productChoise, Inventory);

            //checking current balance, if payment is needed
            if (Money < productPrice)
            {
                //Vipps payment
                if (paymentChoise == '1')
                {
                    int receivedMoney;
                    while (true)
                    {
                        Console.WriteLine($"\nSend (type amount) {productPrice - Money}$ to Vipps number: 47661550");
                        receivedMoney = Convert.ToInt32(Console.ReadLine());
                        Money += receivedMoney;
                        Console.Clear();
                        Console.WriteLine($"\nPayment of {receivedMoney}$ through {PaymentID.Vipps} received\n");
                        Thread.Sleep(2000);
                        Console.Clear();

                        if (Money < productPrice)
                        {
                            Console.Clear();
                            Console.WriteLine($"Total deposited amount ({Money}$) is less than product price: {productPrice}$" +
                                $"\nPlease Vipps {productPrice - Money}$ to complete purchase");
                        }
                        else
                            break;

                        Thread.Sleep(1000);
                        
                    }

                }
                //Cash payment
                else if (paymentChoise == '2' && Money < productPrice)
                {
                    Console.WriteLine($"\nInsert (type money amount) {productPrice - Money}$ or more into machine slot:");
                    /// Asuming payment is made with coins or notes
                    double moneyReceived = Convert.ToDouble(Console.ReadLine());
                    Money += moneyReceived;
                    Console.Clear();

                    Console.WriteLine($"{moneyReceived}$ received");
                    
                }
                else
                {
                    Console.WriteLine("No valid payment choise was made. Returning to main menu.");
                }
            }
            else
            {
                Console.WriteLine($"Current balance: ({Money}$)\nPaying for product with deposited funds.");
                Money -= productPrice;
            }
        }

        private int GettingProductPrice(char productChoise, Dictionary<char, Confectionary> Inventory)
        {
            int productPrice = 0;
            foreach (var product in Inventory)
            {
                if (productChoise == product.Key)
                {
                    productPrice = product.Value.Price;
                }
            }
            return productPrice;
        }

        public void DepositMoney()
        {
            Console.Clear();
            Console.WriteLine("Please insert (type amount) coins or notes: ");
            double moneyReceived = Convert.ToDouble(Console.ReadLine());
            Money += moneyReceived;
            Console.WriteLine($"{moneyReceived}$ received.\nCurrent balance: {Money}$");
        }

        public void ReturningChange()
        {
            if (Money > 0)
            {
                Console.Clear();
                Console.WriteLine($"\n{Money}$ payed out..");
                Thread.Sleep(2000);
                Console.WriteLine("\nPlease collect your change below");
                Money = 0;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\nNo funds to pay out.");
                Thread.Sleep(2000);
                Console.WriteLine($"Current balance: {Money}$");
            }
        }

        
    }
}
