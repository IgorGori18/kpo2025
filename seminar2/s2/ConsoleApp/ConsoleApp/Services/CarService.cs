using ConsoleApp.Abstractions;
using ConsoleApp.Abstractions.Abstractions;
using ConsoleApp.Services.Abstractions;

namespace ConsoleApp.Services;

public class CarService : ICarProvider
{
    private readonly LinkedList<Car> _cars = new();
    
    public void AddCar<TParams>(ICarFactory<TParams> carFactory, TParams carParams)
        where TParams : EngineParamsBase
    {
        var car = carFactory.CreateCar(carParams, Guid.NewGuid());
        _cars.AddLast(car);
    }

    public Car? TakeCar(Customer customer)
    {
        var car = _cars.FirstOrDefault(x => x.IsCompatible(customer));

        if (car is not null)
        {
            _cars.Remove(car);
        }
        
        return car;
    }

    public IEnumerable<Car> GetAllCars() => _cars.ToList().AsReadOnly();
    
    
}