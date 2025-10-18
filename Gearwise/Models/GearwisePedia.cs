namespace Gearwise.Models
{
    public class GearwisePedia
    {
        public int GearwisePediaId { get; set; }
        public string Title { get; set; }
        public ProductSpecification ProductSpecification { get; set; }

        public GearwisePedia() { }

        public GearwisePedia(int gearwisePediaId, string title, ProductSpecification productSpecification)
        {
            GearwisePediaId = gearwisePediaId;
            Title = title;
            ProductSpecification = productSpecification;
        }
    }
}
