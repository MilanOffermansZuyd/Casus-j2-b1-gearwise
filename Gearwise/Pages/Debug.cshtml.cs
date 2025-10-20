using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages
{
    public class DebugModel : PageModel
    {
        private readonly GearwiseDatabase Database;

        public List<User> Users { get; set; } = new List<User>();

        public List<Brand> Brands { get; set; } = new List<Brand>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<PaymentOption> PaymentOptions { get; set; } = new List<PaymentOption>();

        public List<Message> Messages { get; set; } = new List<Message>();

        public List<Payment> Payments { get; set; } = new List<Payment> { };

        public List<Product> Products { get; set; } = new List<Product> { };

        public List<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification> { };

        public List<GearwisePedia> GearwisePedias { get; set; } = new List<GearwisePedia>();

        public List<Advert> Adverts { get; set; } = new List<Advert>();

        
        public DebugModel(GearwiseDatabase database)
        {
            Database = database;
        }

        public async Task OnGet()
        {
            Users = await Database.GetUsersDEBUGAsync();

            Brands = await Database.GetBrandsDEBUGAsync();

            Categories = await Database.GetCategoriesDEBUGAsync();

            PaymentOptions = await Database.GetPaymentOptionsDEBUGAsync();

            Messages = await Database.GetMessagesDEBUGAsync();

            Payments = await Database.GetPaymentsDEBUGAsync();

            Products = await Database.GetProductsDEBUGAsync();

            ProductSpecifications = await Database.GetProductSpecificationsDEBUGAsync();

            GearwisePedias = await Database.GetGearwisePediasDEBUGAsync();

            Adverts = await Database.GetAdvertsDEBUGAsync();
        }
    }
}
