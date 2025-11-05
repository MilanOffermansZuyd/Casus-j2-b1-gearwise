using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class UpdateBrandModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public string ErrorMessage { get; set; }
        public UpdateBrandModel(GearwiseDatabase db)
        {
            Db = db;
        }
        [BindProperty]
        public Brand? Brand { get; set; }
        public async Task OnGetAsync(int id)
        {
            if (id == null) 
            {
                return;
            }

            Brand = await Db.GetBrandAsync(id);
        }
        public async Task<IActionResult> OnPostAsync(int id,string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ErrorMessage = "Check uw invoervleden.";
                return Page();
            }
            var brand = new Brand(id, name);

            var result = await Db.EditBrandAsync(brand);

            if (result == null)
            {
                ErrorMessage = "oops er is geen resultaat gevonden probeerd het later nog eens";
                return Page();
            }

            return RedirectToPage("adminpage", new { View = "ManageBrands" });
        }
    }
}
