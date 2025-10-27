using Gearwise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gearwise.Pages;

public class ProducPageModel : PageModel
{
    [BindProperty]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    public void OnGet()
    {

    }
}
