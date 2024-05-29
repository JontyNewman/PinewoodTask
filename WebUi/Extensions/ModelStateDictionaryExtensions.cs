using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JontyNewman.PinewoodTask.WebUi.Extensions;

public static class ModelStateDictionaryExtensions
{
    public static bool IsInvalid(this ModelStateDictionary modelState, params string[] keys)
        => modelState.GetFieldValidationState(string.Join(".", keys)) == ModelValidationState.Invalid;
}
