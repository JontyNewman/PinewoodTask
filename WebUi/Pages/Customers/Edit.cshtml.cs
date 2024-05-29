using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JontyNewman.PinewoodTask.WebUi.Pages.Customers;

public class EditModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    public Customer Customer { get; set; } = new();

    private readonly ICustomerRepository _repo;

    private readonly IValidator<Customer> _validator;

    public EditModel(ICustomerRepository repo, IValidator<Customer> validator)
    {
        _repo = repo;
        _validator = validator;
    }

    public IActionResult OnGet()
    {
        var customer = _repo.Fetch(Id);

        if (customer is null)
        {
            return NotFound();
        }

        Customer = customer;

        return Page();
    }

    public IActionResult OnPost()
    {
        var result = _validator.Validate(Customer);

        ModelState.ClearValidationState(nameof(Customer));

        if (!result.IsValid)
        {
            result.AddToModelState(ModelState, nameof(Customer));
            return Page();
        }

        Customer.Id = Id;
        Customer.Address.Line2 ??= string.Empty;

        _repo.Update(Customer);

        return RedirectToPage("/Customers");
    }
}
