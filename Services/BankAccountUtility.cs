namespace AmazingFeatures.Services
{
    public static class BankAccountUtility
    {
        //Static method
        public static double CalculateInterest(double balance, double interestRate)
        {
            return balance * (interestRate / 100);
        }
    }
}