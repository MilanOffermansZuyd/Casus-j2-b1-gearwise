namespace Gearwise.Models
{
    public class Message
    {
        public User Sender { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Message(User sender, string title, string body)
        {
            Sender = sender;
            Title = title;
            Body = body;
        }
    }
}
