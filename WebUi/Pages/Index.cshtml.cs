using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JontyNewman.PinewoodTask.WebUi.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
        => RedirectToPage("Customers");
}
