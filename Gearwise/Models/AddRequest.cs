using System.ComponentModel;

namespace Gearwise.Models
{
    public class AddRequest : Message
    {
        public Category Category { get; set; }
        public Brand? Brand { get; set; }

        public AddRequest(int messageId, int senderId, string title, string body, Category category, Brand? brand):
            base(messageId, senderId, title, body)
        {
            Category = category;
            Brand = brand;
        }
    }
}
