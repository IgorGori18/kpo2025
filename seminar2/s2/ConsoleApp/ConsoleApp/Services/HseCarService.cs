using ConsoleApp.Services.Abstractions;

namespace ConsoleApp.Services;

public class HseCarService
{
    private readonly ICarProvider _carProvider;
    private readonly ICustomersProvider _customerProvider;
    
    public HseCarService(ICarProvider carProvider, ICustomersProvider customerProvider)
    {
        _carProvider = carProvider;
        _customerProvider = customerProvider;
    }
    
    public void SellCars()
    {
        var customers = _customerProvider.GetCustomers();

        foreach (var customer in customers)
        {
            if (customer.Car != null)
                continue;

            var car = _carProvider.TakeCar(customer);

            if (car == null)
                continue;

            customer.Car = car;
        }
    }
}