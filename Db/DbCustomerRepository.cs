
using Microsoft.EntityFrameworkCore;

namespace JontyNewman.PinewoodTask.Db;
public class DbCustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public DbCustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> FetchAll()
    {
        return _context.Customers
            .Where(c => c.Removed == null);
    }
    public void Add(Customer customer)
    {
        _ = _context.Customers.Add(customer);
        _ = _context.SaveChanges();
    }

    public Customer? Fetch(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer is null)
        {
            return null;
        }

        if (customer.Removed is not null)
        {
            return null;
        }

        return customer;
    }

    public void Update(Customer customer)
    {
        _ = _context.Customers.Update(customer);
        _ = _context.SaveChanges();
    }

    public void Remove(int id)
    {
        // .ExecuteUpdate() would be more efficient if we were using a relational database.

        var customer = Fetch(id);

        if (customer is null)
        {
            return;
        }

        customer.Removed = DateTime.UtcNow;
        Update(customer);
    }
}
