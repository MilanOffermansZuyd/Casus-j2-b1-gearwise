namespace Gearwise.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        public List<Advert> Adverts { get; set; } = new List<Advert>();

        public Brand() { }

        public Brand(int brandId, string name)
        {
            BrandId = brandId;
            Name = name;
        }
    }
}
