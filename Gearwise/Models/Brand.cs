namespace Gearwise.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        public Brand() { }

        public Brand(int brandId, string name)
        {
            BrandId = brandId;
            Name = name;
        }
    }
}
