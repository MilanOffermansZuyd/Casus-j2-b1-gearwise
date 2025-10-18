namespace Gearwise.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Message() { }

        public Message(int messageId, int senderId, string title, string body)
        {
            MessageId = messageId;
            SenderId = senderId;
            Title = title;
            Body = body;
        }
    }
}
