using ConsoleApp1.context;
using ConsoleApp1.models;

namespace ConsoleApp1.Repository;

public class CustomerRepository
{
    private readonly MyDbContext _context;

    public CustomerRepository(MyDbContext context)
    {
        _context = context;
    }

    public void Save(Customer customer)
    {
        if (customer.Id == 0)
        {
            _context.Customers.Add(customer);
        }
        else
        {
            _context.Customers.Update(customer);
        }
        _context.SaveChanges();
    }

    public List<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }
}
