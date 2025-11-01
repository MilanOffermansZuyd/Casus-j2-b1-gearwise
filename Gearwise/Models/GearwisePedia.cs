namespace Gearwise.Models
{
    public class GearwisePedia
    {
        public int GearwisePediaId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public GearwisePedia() { }

        public GearwisePedia(int gearwisePediaId, string title, string body)
        {
            GearwisePediaId = gearwisePediaId;
            Title = title;
            Body = body;
        }
    }
}
