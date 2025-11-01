using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gearwise.Pages
{
    public class ProductCreateModel : PageModel
    {
        private readonly GearwiseDatabase Db;

        public ProductCreateModel(GearwiseDatabase db)
        {
            Db = db;
        }

        [BindProperty]
        public Product Product { get; set; }
        public string? Errormessage { get; set; }
        public SelectList BrandList { get; set; }
        public SelectList CategoryList { get; set; }
        public async Task OnGetAsync()
        {
            BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
            CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Errormessage = "Oops er gaat iets fout pas uw velden aan";
                BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
                return Page();
            }

            await Db.AddProductAsync(Product);
            return RedirectToPage("CreateAdvert");
        }  
    }
}
