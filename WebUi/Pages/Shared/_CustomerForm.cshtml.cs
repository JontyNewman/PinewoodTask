using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JontyNewman.PinewoodTask.WebUi.Pages.Shared;

public class CustomerForm
{
    public Customer Customer { get; set; } = new();

    public ModelStateDictionary ModelState { get; set; } = new();

    public IEnumerable<string> Root { get; set; } = Enumerable.Empty<string>();
}
