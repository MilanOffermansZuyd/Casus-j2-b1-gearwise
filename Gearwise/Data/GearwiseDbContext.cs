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

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Adverts)
                .WithOne(a => a.Brand)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Adverts)
                .WithOne(a => a.Category)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Adverts)
                .WithOne(a => a.Seller)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
                .HasMany<Message>()
                .WithOne(m => m.Sender)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<PaymentOption>()
                .HasMany<Payment>()
                .WithOne(p => p.PaymentOption)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Brand>()
                .HasMany<ProductSpecification>()
                .WithOne(ps => ps.Brand)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Category>()
                .HasMany<ProductSpecification>()
                .WithOne(ps => ps.Category)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ProductSpecification>()
               .HasMany<GearwisePedia>()
               .WithOne(gp => gp.ProductSpecification)
               .OnDelete(DeleteBehavior.ClientCascade);



            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User(1, "Henk", "Jansen", "test@test.nl", "testwachtwoord", "0612345678", RoleStates.User),
                new User(2, "Dirk", "van den broek", "dvdb@test.nl", "testwachtwoord", "0687654321", RoleStates.User),
                new User(3, "Michel", "Peters", "mp@test.nl", "testwachtwoord", "0687654321", RoleStates.User)
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

            modelBuilder.Entity<Advert>().HasData(
                new Advert(1, "Banden te koop", 1, 1, 1),
                new Advert(2, "Schokdemper te koop", 2, 2, 3),
                new Advert(3, "Uitlaat te koop", 1, 3, 3)
                );

            modelBuilder.Entity<Message>().HasData(
                new Message(1, 1, "Aankoop banden", "Dit is een testbericht"),
                new Message(2, 2, "Aankoop schokdemper", "Dit is een testbericht")
                );

            modelBuilder.Entity<Payment>().HasData(
                new Payment(1, 1, 1),
                new Payment(2, 2, 1),
                new Payment(3, 3, 1)
                );

            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Uitlaat", 001, ProductStates.InStock, "Een RVS Uitlaat", 200),
                new Product(2, "Velg", 001, ProductStates.OutOfStock, "Een RVS Velg", 200),
                new Product(3, "Powerfilter", 001, ProductStates.Discontinued, "Voor de meeste power", 200)
                );

            modelBuilder.Entity<ProductSpecification>().HasData(
                new ProductSpecification(1, 1, 1),
                new ProductSpecification(2, 2, 2),
                new ProductSpecification(3, 3, 3)
                );

            modelBuilder.Entity<GearwisePedia>().HasData(
                new GearwisePedia(1, "De", 1),
                new GearwisePedia(2, "Gearwise", 2),
                new GearwisePedia(3, "Pedia", 3)
                );
    }
    }
}
