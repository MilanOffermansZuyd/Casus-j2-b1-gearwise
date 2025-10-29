using Gearwise.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Gearwise.Models;

namespace Gearwise.Pages
{
    
    public class AdminPageModel : PageModel
    {
        private readonly GearwiseDatabase Database;
        [BindProperty(SupportsGet = true)]
        public string? View { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Advert> Adverts { get; set; } = new List<Advert>();
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public AdminPageModel(GearwiseDatabase database)
        {
            Database = database;
        }
        public async Task OnGet()
        {
            switch (View)
            {
                case "ManageUsers":
                    await GetAllUsersAsync();
                    break;
                case "ManageAdverts":
                    await GetAllAdvertsAsync();
                    break;
                case "ManageBrands":
                    await GetAllBrandsAsync();
                    break;
                case "ManageCategories":
                    await GetAllCategoriesAsync();
                    break;
                default:
                    break;
            }
        }

        public async Task GetAllUsersAsync()
        {
            var gebruiker = await Database.GetUsersAsync();
            foreach (var u in gebruiker)
            {
                Users.Add(u);
            }
        }
        public async Task GetAllAdvertsAsync()
        {
             var adverts = await Database.GetAdvertsAsync();
            foreach (var a in adverts)
            {
                Adverts.Add(a);
            }
        }
        public async Task GetAllBrandsAsync()
        {
            var brands = await Database.GetBrandsAsync();
            foreach (var b in brands)
            {
                Brands.Add(b);
            }
        }
        public async Task GetAllCategoriesAsync()
        {
            var categories = await Database.GetCategoriesAsync();
            foreach (var c in categories)
            {
                Categories.Add(c);
            }
        }
    }
}
