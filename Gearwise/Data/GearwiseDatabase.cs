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

        // ------------------------------------------------------------- DEBUG -------------------------------------------------------------

        public async Task<List<User>> GetUsersDEBUGAsync()
        {
            return await Database.Users.ToListAsync();
        }

        public async Task<List<Advert>> GetAdvertsDEBUGAsync()
        {
            return await Database.Adverts.ToListAsync();
        }

        public async Task<List<Message>> GetMessagesDEBUGAsync()
        {
            return await Database.Messages.ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsDEBUGAsync()
        {
            return await Database.Payments.ToListAsync();
        }

        public async Task<List<PaymentOption>> GetPaymentOptionsDEBUGAsync()
        {
            return await Database.PaymentOptions.ToListAsync();
        }

        public async Task<List<Product>> GetProductsDEBUGAsync()
        {
            return await Database.Products.ToListAsync();
        }

        public async Task<List<ProductSpecification>> GetProductSpecificationsDEBUGAsync()
        {
            return await Database.ProductSpecifications.ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesDEBUGAsync()
        {
            return await Database.Categories.ToListAsync();
        }

        public async Task<List<GearwisePedia>> GetGearwisePediasDEBUGAsync()
        {
            return await Database.GearwisePedias.ToListAsync();
        }

        public async Task<List<Brand>> GetBrandsDEBUGAsync()
        {
            return await Database.Brands.ToListAsync();
        }

        // ------------------------------------------------------------- EINDE DEBUG -------------------------------------------------------------


        // USERS
        // READ
        public async Task<List<User>> GetUsersAsync()
        {
            return await Database.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await Database.Users.FindAsync(id);
        }

        // CREATE
        public async Task<User> AddUserAsync(User user)
        {
            Database.Users.Add(user);
            await Database.SaveChangesAsync();
            return user;
        }

        // UPDATE
        public async Task<User?> EditUserAsync(User user)
        {
            var ExistingUser = await GetUserAsync(user.UserId);
            if (ExistingUser != null)
            {
                Database.Entry(ExistingUser).CurrentValues.SetValues(user);
            }
            await Database.SaveChangesAsync();
            return ExistingUser;
        }

        // DELETE
        public async Task<bool> DeleteUserAsync(int id)
        {
            var User = await GetUserAsync(id);
            if (User != null)
            {
                Database.Users.Remove(User);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // ADVERTS
        // READ
        public async Task<List<Advert>> GetAdvertsAsync()
        {
            return await Database.Adverts
                .Include(a => a.Brand)
                .Include(a => a.Category)
                .Include(a => a.Seller)
                .Include(a => a.Products)
                .ToListAsync();
        }
        
        public async Task<Advert?> GetAdvertAsync(int id)
        {
            return await Database.Adverts
                .Include(a => a.Brand)
                .Include(a => a.Category)
                .Include(a => a.Seller)
                .Include(a => a.Products)
                .FirstOrDefaultAsync(a => a.AdvertId == id);
        }

        // CREATE
        public async Task<Advert> AddAdvertAsync(Advert advert)
        {
            Database.Adverts.Add(advert);
            await Database.SaveChangesAsync();
            return advert;
        }

        // UPDATE
        public async Task<Advert?> EditAdvertAsync(Advert advert)
        {
            var ExistingAdvert = await GetAdvertAsync(advert.AdvertId);
            if (ExistingAdvert != null)
            {
                Database.Entry(ExistingAdvert).CurrentValues.SetValues(advert);

                ExistingAdvert.BrandId = advert.BrandId;
                ExistingAdvert.CategoryId = advert.CategoryId;
                ExistingAdvert.SellerId = advert.SellerId;
            }
            await Database.SaveChangesAsync();
            return ExistingAdvert;
        }

        // DELETE
        public async Task<bool> DeleteAdvertAsync(int id)
        {
            var Advert = await GetAdvertAsync(id);
            if (Advert != null)
            {
                Database.Adverts.Remove(Advert);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // MESSAGES
        // READ
        public async Task<List<Message>> GetMessagesAsync()
        {
            return await Database.Messages
                .Include(m => m.Sender)
                .ToListAsync();
        }

        public async Task<Message?> GetMessageAsync(int id)
        {
            return await Database.Messages
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.MessageId == id);
        }

        // CREATE
        public async Task<Message> AddMessageAsync(Message message)
        {
            Database.Messages.Add(message);
            await Database.SaveChangesAsync();
            return message;
        }

        // UPDATE
        public async Task<Message?> EditMessageAsync(Message message)
        {
            var ExistingMessage = await GetMessageAsync(message.MessageId);
            if (ExistingMessage != null)
            {
                Database.Entry(ExistingMessage).CurrentValues.SetValues(message);
            }
            await Database.SaveChangesAsync();
            return ExistingMessage;
        }

        // DELETE
        public async Task<bool> DeleteMessageAsync(int id)
        {
            var Message = await GetMessageAsync(id);
            if (Message != null)
            {
                Database.Messages.Remove(Message);
                await Database.SaveChangesAsync();
                return true;
            }    
            return false;
        }


        // PAYMENTS
        // READ
        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await Database.Payments
                .Include(p => p.PaymentOption)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentAsync(int id)
        {
            return await Database.Payments
                .Include(p => p.PaymentOption)
                .FirstOrDefaultAsync(p => p.PaymentId == id);
        }

        // CREATE
        public async Task<Payment> AddPaymentAsync(Payment payment)
        {
            Database.Payments.Add(payment);
            await Database.SaveChangesAsync();
            return payment;
        }

        // UPDATE
        public async Task<Payment?> EditPaymentAsync(Payment payment)
        {
            var ExistingPayment = await GetPaymentAsync(payment.PaymentId);
            if (ExistingPayment != null)
            {
                Database.Entry(ExistingPayment).CurrentValues.SetValues(payment);

                ExistingPayment.PaymentOptionId = payment.PaymentOptionId;
            }
            await Database.SaveChangesAsync();
            return ExistingPayment;
        }

        // DELETE
        public async Task<bool> DeletePaymentAsync(int id)
        {
            var Payment = await GetPaymentAsync(id);
            if (Payment != null)
            {
                Database.Payments.Remove(Payment);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // PAYMENTOPTIONS
        // READ
        public async Task<List<PaymentOption>> GetPaymentOptionsAsync()
        {
            return await Database.PaymentOptions.ToListAsync();
        }

        public async Task<PaymentOption?> GetPaymentOptionAsync(int id)
        {
            return await Database.PaymentOptions.FindAsync(id);
        }

        // CREATE
        public async Task<PaymentOption> AddPaymentOptionAsync(PaymentOption paymentOption)
        {
            Database.PaymentOptions.Add(paymentOption);
            await Database.SaveChangesAsync();
            return paymentOption;
        }

        // UPDATE
        public async Task<PaymentOption?> EditPaymentOptionAsync(PaymentOption paymentOption)
        {
            var ExistingPaymentOption = await GetPaymentOptionAsync(paymentOption.PaymentOptionId);
            if (ExistingPaymentOption != null)
            {
                Database.Entry(ExistingPaymentOption).CurrentValues.SetValues(paymentOption);
            }
            await Database.SaveChangesAsync();
            return ExistingPaymentOption;
        }

        // DELETE
        public async Task<bool> DeletePaymentOptionAsync(int id)
        {
            var PaymentOption = await GetPaymentOptionAsync(id);
            if (PaymentOption != null)
            {
                Database.PaymentOptions.Remove(PaymentOption);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // PRODUCTS
        // READ
        public async Task<List<Product>> GetProductsAsync()
        {
            return await Database.Products.ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await Database.Products.FindAsync(id);
        }

        // CREATE
        public async Task<Product> AddProductAsync(Product product)
        {
            Database.Products.Add(product);
            await Database.SaveChangesAsync();
            return product;
        }

        // UPDATE
        public async Task<Product?> EditProductAsync(Product product)
        {
            var ExistingProduct = await GetProductAsync(product.ProductId);
            if (ExistingProduct != null)
            {
                Database.Entry(ExistingProduct).CurrentValues.SetValues(product);
            }
            await Database.SaveChangesAsync();
            return ExistingProduct;
        }

        // DELETE
        public async Task<bool> DeleteProductAsync(int id)
        {
            var Product = await GetProductAsync(id);
            if (Product != null)
            {
                Database.Products.Remove(Product);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // PRODUCTSPECIFICATIONS
        // READ
        public async Task<List<ProductSpecification>> GetProductSpecificationsAsync()
        {
            return await Database.ProductSpecifications
                .Include(ps => ps.Brand)
                .Include(ps => ps.Category)
                .ToListAsync();
        }

        public async Task<ProductSpecification?> GetProductSpecificationAsync(int id)
        {
            return await Database.ProductSpecifications
                .Include(ps => ps.Brand)
                .Include(ps => ps.Category)
                .FirstOrDefaultAsync(ps => ps.ProductSpecificationId == id);
        }


        // CREATE
        public async Task<ProductSpecification> AddProductSpecificationAsync(ProductSpecification productSpecification)
        {
            Database.ProductSpecifications.Add(productSpecification);
            await Database.SaveChangesAsync();
            return productSpecification;
        }

        // UPDATE
        public async Task<ProductSpecification?> EditProductSpecificationAsync(ProductSpecification productSpecification)
        {
            var ExistingProductSpecification = await GetProductSpecificationAsync(productSpecification.ProductSpecificationId);
            if (ExistingProductSpecification != null)
            {
                Database.Entry(ExistingProductSpecification).CurrentValues.SetValues(productSpecification);

                ExistingProductSpecification.BrandId = productSpecification.BrandId;
                ExistingProductSpecification.CategoryId = productSpecification.CategoryId;
            }
            await Database.SaveChangesAsync();
            return ExistingProductSpecification;
        }

        // DELETE
        public async Task<bool> DeleteProductSpecificationAsync(int id)
        {
            var ProductSpecification = await GetProductSpecificationAsync(id);
            if (ProductSpecification != null)
            {
                Database.ProductSpecifications.Remove(ProductSpecification);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // CATEGORY
        // READ
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await Database.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            return await Database.Categories.FindAsync(id);
        }

        // CREATE
        public async Task<Category> AddCategoryAsync(Category category)
        {
            Database.Categories.Add(category);
            await Database.SaveChangesAsync();
            return category;
        }

        // UPDATE
        public async Task<Category?> EditCategoryAsync(Category category)
        {
            var ExistingCategory = await GetCategoryAsync(category.CategoryId);
            if (ExistingCategory != null)
            {
                Database.Entry(ExistingCategory).CurrentValues.SetValues(category);
            }
            await Database.SaveChangesAsync();
            return ExistingCategory;
        }

        // DELETE
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var Category = await GetCategoryAsync(id);
            if (Category != null)
            {
                Database.Categories.Remove(Category);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // GEARWISEPEDIA
        // READ
        public async Task<List<GearwisePedia>> GetGearwisePediasAsync()
        {
            return await Database.GearwisePedias
                .Include(g => g.ProductSpecification)
                .ThenInclude(ps => ps.Brand)
                .Include(g => g.ProductSpecification)
                .ThenInclude(ps => ps.Category)
                .ToListAsync();
        }

        public async Task<GearwisePedia?> GetGearwisePediaAsync(int id)
        {
            return await Database.GearwisePedias
                .Include(g => g.ProductSpecification)
                .ThenInclude(ps => ps.Brand)
                .Include(g => g.ProductSpecification)
                .ThenInclude(ps => ps.Category)
                .FirstOrDefaultAsync(g => g.GearwisePediaId == id);
        }

        // CREATE
        public async Task<GearwisePedia> AddGearwisePediaAsync(GearwisePedia gearwisePedia)
        {
            Database.GearwisePedias.Add(gearwisePedia);
            await Database.SaveChangesAsync();
            return gearwisePedia;
        }

        // UPDATE
        public async Task<GearwisePedia?> EditGearwisePediaAsync(GearwisePedia gearwisePedia)
        {
            var ExistingGearwisePedia = await GetGearwisePediaAsync(gearwisePedia.GearwisePediaId);
            if (ExistingGearwisePedia != null)
            {
                Database.Entry(ExistingGearwisePedia).CurrentValues.SetValues(gearwisePedia);

                ExistingGearwisePedia.ProductSpecificationId = gearwisePedia.ProductSpecificationId;
            }
            await Database.SaveChangesAsync();
            return ExistingGearwisePedia;
        }

        // DELETE
        public async Task<bool> DeleteGearwisePediaAsync(int id)
        {
            var GearwisePedia = await GetGearwisePediaAsync(id);
            if (GearwisePedia != null)
            {
                Database.GearwisePedias.Remove(GearwisePedia);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }


        // BRANDS
        // READ
        public async Task<List<Brand>> GetBrandsAsync()
        {
            return await Database.Brands.ToListAsync();
        }

        public async Task<Brand?> GetBrandAsync(int id)
        {
            return await Database.Brands.FindAsync(id);
        }

        // CREATE
        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            Database.Brands.Add(brand);
            await Database.SaveChangesAsync();
            return brand;
        }

        // UPDATE
        public async Task<Brand?> EditBrandAsync(Brand brand)
        {
            var ExistingBrand = await GetBrandAsync(brand.BrandId);
            if (ExistingBrand != null)
            {
                Database.Entry(ExistingBrand).CurrentValues.SetValues(brand);
            }
            await Database.SaveChangesAsync();
            return ExistingBrand;
        }

        // DELETE
        public async Task<bool> DeleteBrandAsync(int id)
        {
            var Brand = await GetBrandAsync(id);
            if (Brand != null)
            {
                Database.Brands.Remove(Brand);
                await Database.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
