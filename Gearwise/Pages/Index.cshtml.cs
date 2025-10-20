using Gearwise.Data;
using Gearwise.Models;
using Gearwise.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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



        public async Task OnGetAsync()
        {
            Adverts = await Database.GetAdvertsAsync();
        }
    }
}
