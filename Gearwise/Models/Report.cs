namespace Gearwise.Models
{
    public class Report : Message
    {
        public User ReportedUser { get; set; }
        public string ReportBody { get; set; }

        public Report(int messageId, int senderId,string title,string body, User reportedUser, string reportBody):
            base(messageId, senderId, title, body)
        {
            ReportedUser = reportedUser;
            ReportBody = reportBody;
        }
    }
}
