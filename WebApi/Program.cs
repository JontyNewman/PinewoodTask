using JontyNewman.PinewoodTask;
using JontyNewman.PinewoodTask.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<CustomerDbContext>(options =>
    options.UseInMemoryDatabase(nameof(CustomerDbContext)));

services.AddScoped<ICustomerRepository, DbCustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/customers", (ICustomerRepository repo) =>
{
    return repo.FetchAll();
})
.WithOpenApi();

app.MapPost("/customers", (ICustomerRepository repo, [FromBody] Customer customer) =>
{
    repo.Add(customer);
})
.WithOpenApi();

app.MapGet("/customers/{id}", (ICustomerRepository repo, int id) =>
{
    return repo.Fetch(id);
})
.WithOpenApi();

app.MapPut("/customers/{id}", (ICustomerRepository repo, int id, [FromBody] Customer customer) =>
{
    customer.Id = id;
    repo.Update(customer);
})
.WithOpenApi();

app.MapDelete("/customers/{id}", (ICustomerRepository repo, int id) =>
{
    repo.Remove(id);
})
.WithOpenApi();

app.Run();
