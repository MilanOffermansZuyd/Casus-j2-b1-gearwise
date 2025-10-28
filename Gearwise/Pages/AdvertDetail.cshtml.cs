using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class AdvertDetailModel : PageModel
    {
        public Advert? Advert { get; set; }

        public Product? Product { get; set; }

        public GearwisePedia? GearwisePedia { get; set; }
        public bool ShowGearwisePedia { get; set; } = false;

        private readonly GearwiseDatabase Database;
        public AdvertDetailModel(GearwiseDatabase database)
        {
            Database = database;
        }

        
        public async Task OnGet(int id)
        {
            Advert = await Database.GetAdvertAsync(id);

            if (Advert != null)
            {
                Product = Advert.Products.FirstOrDefault();
                GearwisePedia = await Database.GetGearwisePediaByAdvertAsync(Advert.BrandId, Advert.CategoryId);
            }
        }

        public async Task OnGetGearwisePedia(int id)
        {
            Advert = await Database.GetAdvertAsync(id);

            if (Advert != null)
            {
                GearwisePedia = await Database.GetGearwisePediaByAdvertAsync(Advert.BrandId, Advert.CategoryId);

                if (GearwisePedia != null)
                {
                    ShowGearwisePedia = true;
                }
                else
                {
                    ShowGearwisePedia = false;
                }
            }
        }

        public async Task<IActionResult> OnPostDeleteGearwisePediaAsync(int id, int advertId)
        {
            var deleteGearwisePedia = await Database.DeleteGearwisePediaAsync(id);

            if (!deleteGearwisePedia)
            {
                return NotFound();
            }

            return RedirectToPage("/AdvertDetail", new { id = advertId });
        }
    }
}
