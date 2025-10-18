using System.ComponentModel;

namespace Gearwise.Models
{
    public class AddRequest : Message
    {
        public Category Category { get; set; }
        public Brand? Brand { get; set; }
    }
}
