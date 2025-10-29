using System.ComponentModel;
using System.Net.Http.Headers;

namespace Gearwise.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int SellerId { get; set; }
        public User? Seller { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product? Product{ get; set; }
        public Advert() { }

        public Advert(int advertId, string title, int brandId, int categoryId, int sellerId,int productId, int quantity)
        {
            AdvertId = advertId;
            Title = title;
            BrandId = brandId;
            CategoryId = categoryId;
            SellerId = sellerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
