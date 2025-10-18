namespace Gearwise.Models
{
    public class ProductSpecification
    {
        public int ProductSpecificationId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public ProductSpecification() { }

        public ProductSpecification(int productSpecificationId, Brand brand, Category category)
        {
            ProductSpecificationId = productSpecificationId;
            Brand = brand;
            Category = category;
        }
    }
}
