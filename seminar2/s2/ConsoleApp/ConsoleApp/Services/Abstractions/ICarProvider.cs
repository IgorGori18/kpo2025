using ConsoleApp.Abstractions;

namespace ConsoleApp.Services.Abstractions;

public interface ICarProvider
{
    Car? TakeCar(Customer customer);
}