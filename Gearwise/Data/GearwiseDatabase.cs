using Gearwise.Models;
using Microsoft.EntityFrameworkCore;

namespace Gearwise.Data
{
    public class GearwiseDatabase
    {
        GearwiseDbContext Database;
        public GearwiseDatabase(GearwiseDbContext databaseContext)
        {
            Database = databaseContext;
        }

        // USERS
        public async Task<List<User>> GetUsersAsync()
        {
            return await Database.Users.ToListAsync();
        }


        // ADVERTS

        public async Task<List<Advert>> GetAdvertsAsync()
        {
            return await Database.Adverts.ToListAsync();
        }

        // MESSAGES

        // PAYMENTS

        // PAYMENTOPTIONS

        public async Task<List<PaymentOption>> GetPaymentOptionsAsync()
        {
            return await Database.PaymentOptions.ToListAsync();
        }

        // PRODUCTS

        // PRODUCTSPECIFICATIONS

        // CATEGORY

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await Database.Categories.ToListAsync();
        }

        // GEARWISEPEDIA

        // BRANDS

        public async Task<List<Brand>> GetBrandsAsync()
        {
            return await Database.Brands.ToListAsync();
        }
    }
}
