using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly GearwiseDatabase Db;

        public CreateUserModel(GearwiseDatabase db)
        {
            Db = db;
        }

        [BindProperty]
        public User? User { get; set; }

        public string Errormessage { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Errormessage = "Controleer de invoervelden.";
                return Page();
            }

            if (User is null) 
            {
                Errormessage = "Oops er iets fout gegaan probeer het later nog eens.";
                return Page();
            }
            await Db.AddUserAsync(User);
            return RedirectToPage("adminpage", new { View = "ManageUsers" });
        }
    }
}

