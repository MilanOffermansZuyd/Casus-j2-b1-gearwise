namespace Gearwise.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public User Seller { get; set; }
        public List<Product> Products { get; set; }
    }
}
