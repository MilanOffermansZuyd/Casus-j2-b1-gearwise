namespace Gearwise.Models
{
    public class ValidationRequest : Message
    {
        public User Company { get; set; }
        public int KvKNumber { get; set; }

        public ValidationRequest(int messageId, int senderId, string title, string body, User company, int kvkNumber)
            : base(messageId, senderId, title, body)
        {
            Company = company;
            KvKNumber = kvkNumber;
        }
    }
}
