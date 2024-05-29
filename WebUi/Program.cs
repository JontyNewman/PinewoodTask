using FluentValidation;
using JontyNewman.PinewoodTask;
using JontyNewman.PinewoodTask.Http;
using JontyNewman.PinewoodTask.WebUi.Validators;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.
services.AddRazorPages();

services.AddScoped<ICustomerRepository, HttpCustomerRepository>(_ =>
{
    var section = config.GetRequiredSection(nameof(HttpCustomerRepository));
    var uriString = section.GetValue<string>(nameof(HttpClient.BaseAddress)) ?? string.Empty;

    var client = new HttpClient();
    client.BaseAddress = new Uri(uriString);

    return new HttpCustomerRepository(client);
});

services.AddScoped<IValidator<Customer>, CustomerValidator>();
services.AddScoped<IValidator<Address>, AddressValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
