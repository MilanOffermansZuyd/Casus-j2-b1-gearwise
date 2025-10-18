using System.ComponentModel;
using System.Net.Http.Headers;

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

        public Advert(int id, string title, Brand brand, Category category, User seller)
        {
            Id = id;
            Title = title;
            Brand = brand;
            Category = category;
            Seller = seller;
            Products = new List<Product>();
        }
    }
}
