namespace Scott_sVendingMachine
{
    public class Payment
    {
        public double Money { get; set; }
        //TODO:
        //er dette måten å løse tilgang til inventory i annen klasse? for hver instans så vil inventory øke.
        //ønsker ikke å lage ny instans av vendingmachine for å få tilgang her.
        //When receiving more than prodsuctprice? exeption handling? with try agian feature?



        public void MakingPayment(char paymentChoise, char productChoise)
        {   //Hvordan klare seg uten denne instansen.
            VendingMachine vendingMachine = new();

            int productPrice = vendingMachine.GettingProductPrice(productChoise);

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
