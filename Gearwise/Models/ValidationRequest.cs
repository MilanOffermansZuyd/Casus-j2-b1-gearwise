namespace Gearwise.Models
{
    public class ValidationRequest : Message
    {
        public User Company { get; set; }
        public int KvKNumber { get; set; }

        public ValidationRequest(User sender, string title, string body, User company, int kvkNumber)
            : base(sender, title, body)
        {
            Company = company;
            KvKNumber = kvkNumber;
        }
    }
}
