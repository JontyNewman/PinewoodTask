using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JontyNewman.PinewoodTask.WebUi.Extensions;

public static class ValidationResultExtensions
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState, params string[] keys)
    {
        foreach (var error in result.Errors)
        {
            var propName = string.Join(".", keys.Append(error.PropertyName));
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}
