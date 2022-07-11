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
                        Console.Clear();

                        if (receivedMoney >= productPrice - Money)
                        {
                            Console.WriteLine($"\nPayment through {PaymentID.Vipps} received\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Amount paid {receivedMoney}$ is lower than product priceMinusCurrentBalance {productPrice}$");
                        }
                        Thread.Sleep(1000);
                    }
                    // Asuming payment is made to vending machine via Vipps
                    Money += Convert.ToDouble(receivedMoney);

                }
                //Cash payment
                else if (paymentChoise == '2' && Money < productPrice)
                {
                    Console.WriteLine($"\nInsert (type money amount) {productPrice - Money}$ or more into machine slot:");
                    /// Asuming payment is made with coins or notes
                    double moneyReceived = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine($"{moneyReceived}$ received");
                    Money += moneyReceived;
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
            Console.WriteLine($"{moneyReceived}$ received");
        }

        public void ReturningChange()
        {
            if (Money > 0)
            {
                Console.Clear();
                Console.WriteLine($"\n{Money}$ in change payed out..");
                Money = 0;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\nNo funds to pay out. Current balance: {Money}$");
            }
        }

        
    }
}
