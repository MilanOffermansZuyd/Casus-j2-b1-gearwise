using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Gearwise.Pages
{
    public class GearwisePediaCreateModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public GearwisePediaCreateModel(GearwiseDatabase db)
        {
            Db = db;
        }
        [BindProperty]
        public GearwisePedia GearwisePedia { get; set; }

        public string ErrorMessage { get; set;}
        public void OnGet(int specificationId)
        {
            Response.Cookies.Append("specificationId", specificationId.ToString());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!int.TryParse(Request.Cookies["specificationId"],out var specificationId)) 
            {
                ErrorMessage = "ooops something went wrong";
                return Page();
            }
            var productSpecification = await Db.GetProductSpecificationAsync(specificationId);
            if (!ModelState.IsValid) 
            {
                ErrorMessage = "voer alle velden in aub";
                return Page();
            }
            await Db.AddGearwisePediaAsync(specificationId, GearwisePedia);

            var adverts = await Db.GetAdvertsAsync();
            var advert = adverts.Where(a => a.Product.ProductSpecificationId == specificationId).FirstOrDefault();
            return RedirectToPage("/AdvertDetail", new { id = advert.AdvertId });
        }
    }
}
