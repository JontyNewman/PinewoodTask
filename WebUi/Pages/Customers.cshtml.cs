using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JontyNewman.PinewoodTask.WebUi.Pages;

public class CustomersModel : PageModel
{
    [BindProperty]
    public Customer Customer { get; set; } = new();

    public IEnumerable<Customer> Customers { get; set; } = Enumerable.Empty<Customer>();

    private readonly ICustomerRepository _repo;

    public CustomersModel(ICustomerRepository repo)
    {
        _repo = repo;
    }

    public void OnGet()
    {
        Customers = _repo.FetchAll();
    }
}
