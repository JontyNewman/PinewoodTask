using System.Net.Http.Json;

namespace JontyNewman.PinewoodTask.Http;

public class HttpCustomerRepository : ICustomerRepository
{
    private readonly HttpClient _client;

    public HttpCustomerRepository(HttpClient client)
    {
        _client = client;
    }

    public IEnumerable<Customer> FetchAll()
    {
        var result = _client.GetFromJsonAsync<IEnumerable<Customer>>("customers").Result;
        
        return result ?? Enumerable.Empty<Customer>();
    }

    public void Add(Customer customer)
    {
        var result = _client.PostAsJsonAsync("customers", customer).Result;

        result.EnsureSuccessStatusCode();
    }

    public Customer? Fetch(int id)
    {
        return _client.GetFromJsonAsync<Customer>($"customers/{id}").Result;
    }

    public void Update(Customer customer)
    {
        var result = _client.PutAsJsonAsync($"customers/{customer.Id}", customer).Result;

        result.EnsureSuccessStatusCode();
    }

    public void Remove(int id)
    {
        var result = _client.DeleteAsync($"customers/{id}").Result;

        result.EnsureSuccessStatusCode();
    }
}
