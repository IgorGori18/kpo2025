using ConsoleApp.Abstractions;
using ConsoleApp.Services.Abstractions;

namespace ConsoleApp.Services;

public class CustomersStorage : ICustomersProvider
{

    public List<Customer> Customers { get; }

    public CustomersStorage()
    {
        Customers = [];
    }

  
    public void AddCustomer(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer, nameof(customer));

        Customers.Add(customer);
    }

    public IEnumerable<Customer> GetCustomers() => Customers.Where(customer => customer.Car == null);
}