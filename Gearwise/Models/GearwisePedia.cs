namespace Gearwise.Models
{
    public class GearwisePedia
    {
        public int GearwisePediaId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public int ProductSpecificationId { get; set; }
        public ProductSpecification ProductSpecification { get; set; }

        public GearwisePedia() { }

        public GearwisePedia(int gearwisePediaId, string title, string body, int productSpecificationId)
        {
            GearwisePediaId = gearwisePediaId;
            Title = title;
            Body = body;
            ProductSpecificationId = productSpecificationId;
        }
    }
}
