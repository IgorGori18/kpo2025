using ConsoleApp.Abstractions;

namespace ConsoleApp.Services.Abstractions;

public interface ICustomersProvider
{
    IEnumerable<Customer> GetCustomers();
}