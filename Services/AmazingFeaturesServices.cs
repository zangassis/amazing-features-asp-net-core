using System.ComponentModel.DataAnnotations;

namespace AmazingFeatures.Services;
public class AmazingFeaturesServices
{
    // Without using pattern matching
    public string GetTransactionDetails(object transaction)
    {
        if (transaction == null)
        {
            return "Invalid transaction.";
        }

        if (transaction is Payment)
        {
            Payment payment = (Payment)transaction;
            return $"Processing payment of {payment.Amount:C} to {payment.Payee}";
        }
        else if (transaction is Transfer)
        {
            Transfer transfer = (Transfer)transaction;
            return $"Transferring {transfer.Amount:C} from {transfer.FromAccount} to {transfer.ToAccount}";
        }
        else if (transaction is Refund)
        {
            Refund refund = (Refund)transaction;
            return $"Processing refund of {refund.Amount:C} to {refund.Customer}";
        }
        else
        {
            return "Unknown transaction type.";
        }
    }

    // Using pattern matching - Switch expression
    public string GetTransactionDetailsUsingPatternMatching(object transaction) => transaction switch
    {
        null => "Invalid transaction.",
        Payment { Amount: var amount, Payee: var payee } =>
            $"Processing payment of {amount:C} to {payee}",
        Transfer { Amount: var amount, FromAccount: var fromAccount, ToAccount: var toAccount } =>
            $"Transferring {amount:C} from {fromAccount} to {toAccount}",
        Refund { Amount: var amount, Customer: var customer } =>
            $"Processing refund of {amount:C} to {customer}",
        _ => "Unknown transaction type."
    };

    // Using pattern matching - Is explicit expression
    public void ValidateObject()
    {
        object obj = "New transaction";

        if (obj is string s)
        {
            Console.WriteLine($"The value is: {s}");
        }
    }

    // Without using Tuples
    static NameParts ExtractNameParts(string fullName)
    {
        var parts = fullName.Split(' ');
        string firstName = parts[0];
        string lastName = parts.Length > 1 ? parts[1] : string.Empty;
        return new NameParts(firstName, lastName);
    }

    public void PrintName()
    {
        string fullName = "John Doe";
        var nameParts = ExtractNameParts(fullName);
        Console.WriteLine($"First Name: {nameParts.FirstName}, Last Name: {nameParts.LastName}");
    }

    // Using Tuples
    static (string FirstName, string LastName) ExtractNamePartsTuple(string fullName)
    {
        var parts = fullName.Split(' ');
        string firstName = parts[0];
        string lastName = parts.Length > 1 ? parts[1] : string.Empty;
        return (firstName, lastName);
    }

    public void PrintNameTuple()
    {
        string fullName = "John Doe";
        var nameParts = ExtractNamePartsTuple(fullName);
        Console.WriteLine($"First Name: {nameParts.FirstName}, Last Name: {nameParts.LastName}");
    }

    // Traditional method
    public int TraditionalSum(int x, int y)
    {
        return x + y;
    }

    // Records
    public void UsingRecordsAndClasses()
    {
        // Using mutable class
        var product1 = new Product("Laptop", 1500.00m, "");
        var product2 = new Product("", 1500.00m, "Electronics");
        product1.Category = "Electronics";
        product2.Name = "Laptop";

        // Class object comparison (by reference)
        Console.WriteLine(product1 == product2); // False (comparison by reference);
        Console.WriteLine(product1.Equals(product2)); // False (no value equality logic);

        // Using immutable record
        var recordProduct1 = new RecordProduct("Laptop", 1500.00m, "Electronics");
        var recordProduct2 = new RecordProduct("Laptop", 1500.00m, "Electronics");

        // Record comparison (by value, native)
        Console.WriteLine(recordProduct1 == recordProduct2); // True (comparison by value);
        Console.WriteLine(recordProduct1.Equals(recordProduct2)); // True (comparison by value);
    }

    // Funct delegate
    // Explicit definition of the delegate
    public delegate int SumDelegate(int a, int b);

    // Using delegate
    static void UsingDelegate()
    {
        // Method reference
        SumDelegate sum = SumMethod;

        Console.WriteLine(sum(3, 4)); // Displays 7
    }

    // Method associated with the delegate
    static int SumMethod(int a, int b)
    {
        return a + b;
    }

    // Using func delegate
    Func<int, int, int> sum = (a, b) => a + b;

    public void UsingFuncDelegate()
    {
        Console.WriteLine(sum(3, 4)); // Displays 7
    }

    public void ProductValidation()
    {
        // Using the validation method
        var product = new Product { Name = "", Category = "keyboard", Price = 100  };
        var errors = product.Validate();
        if (errors.Any())
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }

        // Using data annotations
        var productDataAnnotation = new ProductDataAnnotation { Name = "" };
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(product);

        if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
        {
            foreach (var validationResult in validationResults)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
        }
    }

    // Without using generics
    public int FindMaxInt(List<int> numbers)
    {
        return numbers.Max();
    }

    public double FindMaxDouble(List<double> numbers)
    {
        return numbers.Max();
    }

    public void WithoutUsingGenerics()
    {
        var maxInt = FindMaxInt(new List<int> { 1, 2, 3 });
        var maxDouble = FindMaxDouble(new List<double> { 1.1, 2.2, 3.3 });
    }

    // Using generics
    public T FindMax<T>(List<T> items) where T : IComparable<T>
    {
        return items.Max();
    }

    public void UsingGenerics()
    {
        var maxInt = FindMax(new List<int> { 1, 2, 3 });
        var maxDouble = FindMax(new List<double> { 1.1, 2.2, 3.3 });
    }
}
