using System.ComponentModel;

namespace Gearwise.Models
{
    public class AddRequest : Message
    {
        public Category Category { get; set; }
        public Brand? Brand { get; set; }

        public AddRequest(User sender, string title, string body, Category category, Brand? brand):
            base(sender, title, body)
        {
            Category = category;
            Brand = brand;
        }
    }
}
