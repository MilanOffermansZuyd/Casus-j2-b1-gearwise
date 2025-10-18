using System.ComponentModel;
using System.Net.Http.Headers;

namespace Gearwise.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public User Seller { get; set; }
        public List<Product> Products { get; set; }

        public Advert(int advertId, string title, Brand brand, Category category, User seller)
        {
            AdvertId = advertId;
            Title = title;
            Brand = brand;
            Category = category;
            Seller = seller;
            Products = new List<Product>();
        }
    }
}
