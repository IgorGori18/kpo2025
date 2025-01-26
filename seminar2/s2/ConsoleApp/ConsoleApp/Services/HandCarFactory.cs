using ConsoleApp.Abstractions;
using ConsoleApp.Services.Abstractions;

namespace ConsoleApp.Services;

public class HandCarFactory : ICarFactory<EmptyEngineParams>
{
  
    public Car CreateCar(EmptyEngineParams engineParams, Guid carId)
    {
        var engine = new HandEngine();
        return new Car(engine, carId);
    }
    
}