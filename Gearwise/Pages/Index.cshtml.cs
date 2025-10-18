using Gearwise.Models;
using Gearwise.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Advert> Adverts = new List<Advert>()
        {
            new Advert(1,"tst", new Brand(1, "ets"), new Category(1 , "et"), new User(1, "tst", "test", "test", "pass", 1, RoleStates.Admin)),
            new Advert(1,"eff", new Brand(1, "ff"), new Category(1 , "ff"), new User(1, "hoi", "test", "test", "pass", 1, RoleStates.Admin))
        };


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }



        public void OnGet()
        {

        }
    }
}
