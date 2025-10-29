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
                new Brand(2, "Vredestein"),
                new Brand(3, "Michelen")
                );

            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Banden"),
                new Category(2, "Schokdempers"),
                new Category(3, "Uitlaten"),
                new Category(4, "Velgen")
                );

            modelBuilder.Entity<PaymentOption>().HasData(
                new PaymentOption(1, "Ideal"),
                new PaymentOption(2, "Credit Card"),
                new PaymentOption(3, "Banktransactie")
                );

            modelBuilder.Entity<Advert>().HasData(
                new Advert(1, "Autobanden te koop", 1, 1, 1,1, 10),
                new Advert(2, "Schokdempers te koop", 2, 2, 3,2, 100),
                new Advert(3, "Uitlaat te koop", 1, 3, 3,3, 23),
                new Advert(4, "Velgen te koop", 3, 4, 2,4,1)
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
                new Product(1, "Autobanden", 001, ProductStates.InStock, "Vier nieuwe Continental autobanden", 200,1),
                new Product(2, "Schokdempers", 002, ProductStates.OutOfStock, "Set Vredestein schokdempers", 200, 2),
                new Product(3, "Uitlaten", 003, ProductStates.Discontinued, "RVS uitlaat van Continental", 200, 3),
                new Product(4, "Velgen", 004, ProductStates.InStock, "Nieuwe lichtmetalen velgen", 400, 4)
                );

            modelBuilder.Entity<ProductSpecification>().HasData(
                new ProductSpecification(1, 1, 1),
                new ProductSpecification(2, 2, 2),
                new ProductSpecification(3, 1, 3),
                new ProductSpecification(4, 3, 4)
                );

            modelBuilder.Entity<GearwisePedia>().HasData(
                new GearwisePedia(1, "Continental Banden", "Continental is een Duits bandenmerk bekend om zijn duurzaamheid en prestaties", 1),
                new GearwisePedia(2, "Vredestein Schokdempers", "Vredestein produceert hoogwaardige schokdempers met een focus op comfort", 2),
                new GearwisePedia(3, "Continental Uitlaten", "Continental biedt ook RVS uitlaten aan die bekendstaan om hun lange levensduur", 3)
                );
        }
    }
}
