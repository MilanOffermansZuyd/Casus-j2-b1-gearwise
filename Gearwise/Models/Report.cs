namespace Gearwise.Models
{
    public class Report : Message
    {
        public User ReportedUser { get; set; }
        public string ReportBody { get; set; }
    }
}
