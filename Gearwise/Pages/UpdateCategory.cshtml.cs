using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class UpdateCategoryModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public string ErrorMessage { get; set; }
        public UpdateCategoryModel(GearwiseDatabase db)
        {
            Db = db;
        }
        [BindProperty]
        public Category? Category { get; set; }
        public async Task OnGetAsync(int id)
        {
            if (id == null) 
            {
                return;
            }

            Category = await Db.GetCategoryAsync(id);
        }
        public async Task<IActionResult> OnPostAsync(int id,string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ErrorMessage = "Check uw invoervleden.";
                return Page();
            }
            var category = new Category(id, name);

            var result = await Db.EditCategoryAsync(category);

            if (result == null)
            {
                ErrorMessage = "oops er is geen resultaat gevonden probeerd het later nog eens";
                return Page();
            }

            return RedirectToPage("adminpage", new { View = "ManageCategories" });
        }
    }
}
