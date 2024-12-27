namespace AmazingFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product()
        {
            
        }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public List<string> Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Name))
            {
                errors.Add("The name is required.");
            }
            else if (Name.Length > 100)
            {
                errors.Add("The name must be at most 100 characters long.");
            }

            return errors;
        }
    }
}
