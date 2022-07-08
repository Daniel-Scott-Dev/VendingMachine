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
            VendingMachine vendingMachine = new();

            int productPrice = GettingProductPrice(productChoise ,vendingMachine);
            Console.WriteLine($"Send (type amount) {productPrice}$ to Vipps number: 47661550");

            
            if (paymentChoise == '1')
            {
                ///Getting product price
                foreach (Confectionary inventoryItem in vendingMachine.Inventory)
                {
                    if (productChoise == inventoryItem.ProductID)
                    {
                        productPrice = inventoryItem.Price;
                        return;
                    }
                }
                Console.WriteLine($"Send (type price) {productPrice}$ to Vipps number: 47661550");

                int receivedMoney = Convert.ToInt32(Console.ReadLine());
                if (receivedMoney >= productPrice && paymentChoise == '1')
                {
                    Console.WriteLine($"\nPayment with {PaymentID.Vipps} complete");
                }
                else
                {
                    Console.WriteLine($"\nPayment with {PaymentID.Cash} complete");
                }

                /// Asuming payment is made to vending machine via Vipps
                Money += Convert.ToDouble(productPrice);
            }
            else if (paymentChoise == '2' && Money < productPrice)
            {
                Console.WriteLine($"Insert (type moeny amount) {(Money - productPrice)}$ or more into machine slot:");
                /// Asuming payment is made with coins or notes
                double moneyReceived = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"{moneyReceived}$ received");
                Money += moneyReceived;
            }

            //make this method void and add a menu option of adding money upront?
        }

        private int GettingProductPrice(char productChoise, VendingMachine vendingMachine)
        {
            int productPrice = 0;
            foreach (Confectionary inventoryItem in vendingMachine.Inventory)
            {
                if (productChoise == inventoryItem.ProductID)
                {
                    productPrice = inventoryItem.Price;
                }
            }
            return productPrice;
        }

        public void GivesMoneyBack()
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
