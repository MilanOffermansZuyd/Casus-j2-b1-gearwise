namespace Gearwise.Models
{
    public class ValidationRequest : Message
    {
        public User Company { get; set; }
        public int KvKNumber { get; set; }
    }
}
