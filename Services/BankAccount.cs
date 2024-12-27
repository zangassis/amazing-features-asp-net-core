namespace AmazingFeatures.Services
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public double InterestRate { get; set; }

        //Non-static method
        public BankAccount(double balance, double interestRate)
        {
            Balance = balance;
            InterestRate = interestRate;
        }

        public double CalculateInterest()
        {
            return Balance * (InterestRate / 100);
        }
    }
}
