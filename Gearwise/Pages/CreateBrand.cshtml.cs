using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class CreateBrandModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public string ErrorMessage { get; set; }
        public CreateBrandModel(GearwiseDatabase db)
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
                ErrorMessage = "voer alle velden in";
                return Page();
            }
            var brand = new Brand(null,name);

            var result = await Db.AddBrandAsync(brand);

            if (result == null) 
            {
                return Page();
            }
            
            return RedirectToPage("adminpage", new { View = "ManageBrands" });
        }
    }
}
