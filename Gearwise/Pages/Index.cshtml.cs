using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GearwiseDatabase Database;

        public List<Advert> Adverts { get; set; } = new List<Advert>();

        public IndexModel(ILogger<IndexModel> logger, GearwiseDatabase database)
        {
            _logger = logger;
            Database = database;
        }



        public async Task OnGetAsync(string? sortBy = null)
        {
            Adverts = await Database.GetAdvertsAsync();

            Adverts = sortBy switch
            {
                "title_asc" => Adverts.OrderBy(a => a.Title).ToList(),
                "title_desc" => Adverts.OrderByDescending(a => a.Title).ToList(),
                "brand_asc" => Adverts.OrderBy(b => b.Brand.Name).ToList(),
                "brand_desc" => Adverts.OrderByDescending(b => b.Brand.Name).ToList(),
                "category_asc" => Adverts.OrderBy(c => c.Category.Name).ToList(),
                "category_desc" => Adverts.OrderByDescending(c => c.Category.Name).ToList(),
                _ => Adverts
            };
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await Database.DeleteAdvertAsync(id);
            
            return RedirectToPage();
        }
    }
}
