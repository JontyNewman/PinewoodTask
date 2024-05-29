using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JontyNewman.PinewoodTask.WebUi.Pages.Customers;

public class NewModel : PageModel
{
    [BindProperty]
    public Customer Customer { get; set; } = new();

    private readonly ICustomerRepository _repo;

    private readonly IValidator<Customer> _validator;

    public NewModel(ICustomerRepository repo, IValidator<Customer> validator)
    {
        _repo = repo;
        _validator = validator;
    }

    public void OnGet()
    {
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

        // Optional fields
        Customer.Address.Line2 ??= string.Empty;

        _repo.Add(Customer);

        return RedirectToPage("/Customers");
    }
}
