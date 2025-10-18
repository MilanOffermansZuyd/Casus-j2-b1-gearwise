namespace Gearwise.Models
{
    public class Report : Message
    {
        public User ReportedUser { get; set; }
        public string ReportBody { get; set; }

        public Report(User sender,string title,string body, User reportedUser, string reportBody):
            base(sender, title, body)
        {
            ReportedUser = reportedUser;
            ReportBody = reportBody;
        }
    }
}
