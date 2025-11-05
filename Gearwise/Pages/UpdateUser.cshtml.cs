using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class UpdateUserModel : PageModel
    {
        private readonly GearwiseDatabase Db;

        public UpdateUserModel(GearwiseDatabase db)
        {
            Db = db;
        }

        [BindProperty]
        public User? User { get; set; }

        public string Errormessage { get; set; }

        public async Task OnGetAsync(int id)
        {
            if (id == null)
            {
                Errormessage = "oops er ging iets fout";
                return;
            }
            var user = await Db.GetUserAsync(id);

            if (user is null) 
            {
                Errormessage = "user niet gevonden.";
                return;
            }

            User = user;
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
            await Db.EditUserAsync(User);
            return RedirectToPage("adminpage", new { View = "ManageUsers" });
        }
    }
}

