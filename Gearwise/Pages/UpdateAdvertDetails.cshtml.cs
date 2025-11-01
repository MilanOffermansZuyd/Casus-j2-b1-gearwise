using Gearwise.Data;
using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Gearwise.Pages
{
    public class UpdateAdvertDetailsModel : PageModel
    {
        private readonly GearwiseDatabase Db;
        public UpdateAdvertDetailsModel(GearwiseDatabase db)
        {
            Db = db;
        }
        [BindProperty]
        public Advert? Advert { get; set; }

        public string Errormessage { get; set; }

        [Range(1, 1000, ErrorMessage = "Aantal moet minstens 1 zijn.")]
        public SelectList BrandList { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList SellerList { get; set; }
        public SelectList ProductList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            Advert = await Db.GetAdvertAsync(id);
            BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
            CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
            SellerList = new SelectList(await Db.GetUsersAsync(), "UserId", "FullName");
            ProductList = new SelectList(await Db.GetProductsAsync(), "ProductId", "Name");

            Response.Cookies.Append("AdvertId", id.ToString());
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Errormessage = "Pas de velden aan";
                BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
                SellerList = new SelectList(await Db.GetUsersAsync(), "UserId", "FullName");
                ProductList = new SelectList(await Db.GetProductsAsync(), "ProductId", "Name");
                return Page();
            }

            if (Advert is null)
            {
                Errormessage = "Oops er iets fout gegaan probeer het later nog eens.";
                BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
                SellerList = new SelectList(await Db.GetUsersAsync(), "UserId", "FullName");
                ProductList = new SelectList(await Db.GetProductsAsync(), "ProductId", "Name");
                return Page();
            }

            if (!int.TryParse(Request.Cookies["AdvertId"], out var advertId))
            {
                Errormessage = "someting went wrong";
                return Page();
            }

            Advert.AdvertId = advertId;
            await Db.EditAdvertAsync(Advert);
            return RedirectToPage("index");
        }

        public async Task<IActionResult> OnPostDeleteProductAsync()
        {
            int selectedProductId = Advert.ProductId;
            if (selectedProductId == null || selectedProductId == 0)
            {
                Errormessage = "Selecteer een product die u wilt verwijderen.";
                BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
                SellerList = new SelectList(await Db.GetUsersAsync(), "UserId", "FullName");
                ProductList = new SelectList(await Db.GetProductsAsync(), "ProductId", "Name");
                return Page();
            }


            var result = await Db.DeleteProductAsync(selectedProductId);
            if (!result)
            {
                Errormessage = "Oops er iets fout gegaan met verwijderen.";
                BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
                SellerList = new SelectList(await Db.GetUsersAsync(), "UserId", "FullName");
                ProductList = new SelectList(await Db.GetProductsAsync(), "ProductId", "Name");
                return Page();
            }
            return RedirectToPage("index");
        }

        public async Task<IActionResult> OnPostEditProductAsync()
        {
            int selectedProductId = Advert.ProductId;

            if (selectedProductId == null || selectedProductId == 0)
            {
                Errormessage = "Selecteer een product die u wilt verwijderen.";
                BrandList = new SelectList(await Db.GetBrandsAsync(), "BrandId", "Name");
                CategoryList = new SelectList(await Db.GetCategoriesAsync(), "CategoryId", "Name");
                SellerList = new SelectList(await Db.GetUsersAsync(), "UserId", "FullName");
                ProductList = new SelectList(await Db.GetProductsAsync(), "ProductId", "Name");
                return Page();
            }

            return RedirectToPage("ProductEdit", new { id = selectedProductId });
        }
    }
}
