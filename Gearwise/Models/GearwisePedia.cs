namespace Gearwise.Models
{
    public class GearwisePedia
    {
        public int GearwisePediaId { get; set; }
        public string Title { get; set; }

        public int ProductSpecificationId { get; set; }
        public ProductSpecification ProductSpecification { get; set; }

        public GearwisePedia() { }

        public GearwisePedia(int gearwisePediaId, string title, int productSpecificationId)
        {
            GearwisePediaId = gearwisePediaId;
            Title = title;
            ProductSpecificationId = productSpecificationId;
        }
    }
}
