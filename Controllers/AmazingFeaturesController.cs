using AmazingFeatures.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmazingFeatures.Controllers
{
    public class AmazingFeaturesController : ControllerBase
    {
        public void Process()
        {
            // Usage non static-method
            BankAccount account = new BankAccount(1000, 5);
            double interest = account.CalculateInterest();
            Console.WriteLine($"Interest earned: ${interest}");

            // Usage non static
            double interestStatic = BankAccountUtility.CalculateInterest(1000, 5);
            Console.WriteLine($"Interest earned: ${interestStatic}");
        }
    }
}
