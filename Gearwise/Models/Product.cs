using Gearwise.Models.Enums;

namespace Gearwise.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Serialnumber { get; set; }
        public ProductStates ProductState { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Product(int productId, string name, int serialNumber, ProductStates productState, string description, int price)
        {
            ProductId = productId;
            Name = name;
            Serialnumber = serialNumber;
            ProductState = productState;
            Description = description;
            Price = price;
        }
    }
}
