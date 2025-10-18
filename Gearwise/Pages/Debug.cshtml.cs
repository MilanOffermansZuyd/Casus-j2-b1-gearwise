using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class DebugModel : PageModel
    {
        public List<User> Users { get; set; } = null!;

        public List<Brand> Brands { get; set; } = null;

        public List<Category> Categories { get; set; } = null!; 

        public List<PaymentOption> PaymentOptions { get; set; }

        public List<Advert> Adverts { get; set; } = null!;

        private GearwiseDatabase Database;
        public DebugModel(GearwiseDatabase database)
        {
            Database = database;
        }

        public async Task OnGet()
        {
            Users = await Database.GetUsersAsync();

            Brands = await Database.GetBrandsAsync();

            Categories = await Database.GetCategoriesAsync();

            PaymentOptions = await Database.GetPaymentOptionsAsync();



            Adverts = await Database.GetAdvertsAsync();
        }
    }
}
