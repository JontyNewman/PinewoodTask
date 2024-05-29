namespace JontyNewman.PinewoodTask;

public interface ICustomerRepository
{
    IEnumerable<Customer> FetchAll();

    void Add(Customer customer);

    Customer? Fetch(int id);

    void Update(Customer customer);

    void Remove(int id);
}
