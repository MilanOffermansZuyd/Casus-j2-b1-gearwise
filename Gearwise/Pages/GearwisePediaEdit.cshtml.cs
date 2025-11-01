using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Gearwise.Pages
{
    public class GearwisePediaEditModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public GearwisePediaEditModel(GearwiseDatabase db)
        {
            Db = db;
        }
        [BindProperty]
        public GearwisePedia GearwisePedia { get; set; }

        public string ErrorMessage { get; set; }
        public async Task OnGet(int gearwiseId, int specificationId)
        {
            var gearwise = await Db.GetGearwisePediaAsync(gearwiseId);
            if (gearwise is not null) 
            {
                GearwisePedia = gearwise;
            }
            Response.Cookies.Append("specificationId", specificationId.ToString());
            Response.Cookies.Append("GearwiseId", gearwiseId.ToString());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!int.TryParse(Request.Cookies["GearwiseId"], out var gearwiseId))
            {
                ErrorMessage = "ooops something went wrong";
                return Page();
            }
            if (!int.TryParse(Request.Cookies["specificationId"], out var specificationId))
            {
                ErrorMessage = "ooops something went wrong";
                return Page();
            }

            await Db.EditGearwisePediaAsync(gearwiseId, GearwisePedia);

            var adverts = await Db.GetAdvertsAsync();
            var advert = adverts.Where(a => a.Product.ProductSpecificationId == specificationId).FirstOrDefault();
            return RedirectToPage("/AdvertDetail", new { id = advert.AdvertId });
        }
    }
}

