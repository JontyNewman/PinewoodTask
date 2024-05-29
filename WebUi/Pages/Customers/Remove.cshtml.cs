using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JontyNewman.PinewoodTask.WebUi.Pages.Customers;

public class RemoveModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public Customer Customer { get; set; } = new();

    private readonly ICustomerRepository _repo;

    public RemoveModel(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public IActionResult OnGet()
    {
        return TryInitialize() ? Page() : NotFound();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return TryInitialize() ? Page() : NotFound();
        }

        _repo.Remove(Id);
         
        return RedirectToPage("/Customers");
    }

    private bool TryInitialize()
    {
        var customer = _repo.Fetch(Id);
        var success = customer is not null;

        if (success)
        {
            Initialize(customer!);
        }

        return success;
    }

    private void Initialize(Customer customer)
    {
        Customer = customer;
    }
}
