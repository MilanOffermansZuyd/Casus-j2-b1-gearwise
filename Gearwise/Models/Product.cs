namespace Gearwise.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Serialnumber { get; set; }
        public enum ProductState
        {
            InStock,
            OutOfStock,
            Discontinued
        }
        public ProductState State { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Product(int productId, string name, int serialNumber, ProductState state, string description, int price)
        {
            ProductId = productId;
            Name = name;
            Serialnumber = serialNumber;
            State = state;
            Description = description;
            Price = price;
        }
    }
}
