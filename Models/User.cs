using System.Xml.Linq;

namespace AmazingFeatures.Models
{
    public class User
    {
        // Expression-bodied properties
        private string userName;
        private User(string name) => Name = name;

        public string Name
        {
            get => userName;
            set => userName = value;
        }
    }
}