using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace Gearwise.Pages
{
    public class ProductEditModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public ProductEditModel(GearwiseDatabase db)
        {
            Db = db;
        }
        [BindProperty]
        public Product? Product { get; set; }
        public string? Errormessage { get; set; }
        public SelectList BrandList { get; set; }
        public SelectList CategoryList { get; set; }
        public async Task OnGetAsync(int id)
        {
            var product = await Db.GetProductAsync(id);

            if (product == null)
            {
                Errormessage = "uw product is niet gevonden, probeer het later opnieuw.";
            }
            Product = product;
            Response.Cookies.Append("selectedId", id.ToString());
            Response.Cookies.Append("ProductSpecificationId", product.ProductSpecificationId.ToString());
            BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
            CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (Product is null) 
            {
                return Page();
            }
            if (!int.TryParse(Request.Cookies["selectedId"], out var selectedId)) 
            {
                Errormessage = "someting went wrong";
                return Page();
            }
            if (!int.TryParse(Request.Cookies["ProductSpecificationId"], out var ProductspecificationId))
            {
                Errormessage = "someting went wrong";
                return Page();
            }
            Product.ProductId = selectedId;
            Product.ProductSpecificationId = ProductspecificationId;

           await Db.EditProductAsync(Product);

            return RedirectToPage("CreateAdvert");
        }
    }
}
