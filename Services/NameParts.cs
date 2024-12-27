namespace AmazingFeatures.Services
{
    public class NameParts
    {
        public string FirstName { get; }
        public string LastName { get; }

        public NameParts(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}