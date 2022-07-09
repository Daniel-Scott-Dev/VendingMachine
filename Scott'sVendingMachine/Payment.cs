namespace Scott_sVendingMachine
{
    public class Payment
    {


        public double Money { get; set; }
        //TODO:
        //er dette måten å løse tilgang til inventory i annen klasse?
        //ønsker ikke å lage ny instans av vendingmachine for å få tilgang her. 
        //private readonly IEnumerable<Confectionary> Inventory;
        

        public void MakingPayment(char paymentChoise, char productChoise)
        {
            //VendingMachine vendingMachine = new();

            int productPrice = vendingMachine.GettingProductPrice(productChoise);

            //Vipps payment
            if (paymentChoise == '1')
            {
                Console.WriteLine($"Send (type price) {productPrice}$ to Vipps number: 47661550");
                int receivedMoney = Convert.ToInt32(Console.ReadLine());
                
                if (receivedMoney >= productPrice)
                {
                    Console.WriteLine($"\nPayment with {PaymentID.Vipps} received");
                }
                else
                {
                    Console.WriteLine($"Amount paid {receivedMoney}$ is lower than product price {productPrice}");
                }
                /// Asuming payment is made to vending machine via Vipps
                Money += Convert.ToDouble(productPrice);  
                
            }
            //Cash payment
            else if (paymentChoise == '2' && Money < productPrice)
            {
                Console.WriteLine($"Insert (type moeny amount) {(Money - productPrice)}$ or more into machine slot:");
                /// Asuming payment is made with coins or notes
                double moneyReceived = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"{moneyReceived}$ received");
                Money += moneyReceived;
            }

        }

        public void ReturningChange()
        {
            if (Money > 0)
            {
                Console.WriteLine($"{Money}$ in change payed out..");
                Money = 0;
            }
            else
            {
                Console.WriteLine($"No funds to pay out. Current balance: {Money}$");
            }
        }
    }
}
