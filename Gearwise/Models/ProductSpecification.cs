namespace Gearwise.Models
{
    public class ProductSpecification
    {
        public int ProductSpecificationId { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ProductSpecification() { }

        public ProductSpecification(int productSpecificationId, int brandId, int categoryId)
        {
            ProductSpecificationId = productSpecificationId;
            BrandId = brandId;
            CategoryId = categoryId;
        }
    }
}
