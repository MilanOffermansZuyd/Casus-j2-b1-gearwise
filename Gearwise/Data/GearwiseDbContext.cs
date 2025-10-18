using Gearwise.Models;
using Gearwise.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Gearwise.Data
{
    public class GearwiseDbContext : DbContext
    {
        public GearwiseDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GearwisePedia> GearwisePedias { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User(1, "Henk", "Jansen", "test@test.nl", "testwachtwoord", null, RoleStates.User),
                new User(2, "Dirk", "van den broek", "dvdb@test.nl", "testwachtwoord", null, RoleStates.User),
                new User(3, "Michel", "Peters", "mp@test.nl", "testwachtwoord", null, RoleStates.User)
                );

            modelBuilder.Entity<Brand>().HasData(
                new Brand(1, "Continental"),
                new Brand(2, "Vredestein")
                );

            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Banden"),
                new Category(2, "Schokdempers"),
                new Category(3, "Uitlaten")
                );

            modelBuilder.Entity<PaymentOption>().HasData(
                new PaymentOption(1, "Ideal"),
                new PaymentOption(2, "Credit Card"),
                new PaymentOption(3, "Banktransactie")
                );
        }
    }
}
