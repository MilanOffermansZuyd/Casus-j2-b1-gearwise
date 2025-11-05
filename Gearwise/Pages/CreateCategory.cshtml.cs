using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class CreateCategoryModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public string ErrorMessage { get; set; }
        public CreateCategoryModel(GearwiseDatabase db)
        {
            Db = db;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string name) 
        {
            if (string.IsNullOrWhiteSpace(name)) 
            {
                ErrorMessage = "check uw invoervelden.";
                return Page();
            }
            var brand = new Category(null,name);

            var result = await Db.AddCategoryAsync(brand);

            if (result == null) 
            {
                return Page();
            }
            
            return RedirectToPage("adminpage", new { View = "ManageCategories" });
        }
    }
}
