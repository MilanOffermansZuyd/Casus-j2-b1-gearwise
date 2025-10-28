using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gearwise.Pages
{
    public class CreateAdvertModel : PageModel
    {
        private readonly GearwiseDbContext Context;

        public CreateAdvertModel(GearwiseDbContext context)
        {
            Context = context;
        }

        [BindProperty]
        public Advert? Advert { get; set; }

        [Range(1, 1000, ErrorMessage = "Aantal moet minstens 1 zijn.")]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public SelectList BrandList { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList SellerList { get; set; }
        public SelectList ProductList { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            BrandList = new SelectList(await Context.Brands.ToListAsync(), "BrandId", "Name");
            CategoryList = new SelectList(await Context.Categories.ToListAsync(), "CategoryId", "Name");
            SellerList = new SelectList(await Context.Users.ToListAsync(), "UserId", "FullName");
            ProductList = new SelectList(await Context.Products.ToListAsync(), "ProductId", "Name");

            if (id == null)
            {
                Advert = new Advert();
            }
            else
            {
                Advert = await Context.Adverts.FirstOrDefaultAsync(a => a.AdvertId == id);

                if (Advert == null)
                    return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                BrandList = new SelectList(await Context.Brands.ToListAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Context.Categories.ToListAsync(), "CategoryId", "Name");
                SellerList = new SelectList(await Context.Users.ToListAsync(), "UserId", "FullName");
                ProductList = new SelectList(await Context.Products.ToListAsync(), "ProductId", "Name");
                return Page();
            }

            if (Advert.AdvertId == 0)
                Context.Adverts.Add(Advert);
            else
                Context.Adverts.Update(Advert);

            await Context.SaveChangesAsync();
            return RedirectToPage("index");
        }
    }
}

