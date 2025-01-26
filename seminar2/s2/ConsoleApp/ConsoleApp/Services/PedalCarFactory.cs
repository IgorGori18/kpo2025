using ConsoleApp.Abstractions;
using ConsoleApp.Services.Abstractions;

namespace ConsoleApp.Services;

public class PedalCarFactory : ICarFactory<PedalEngineParams>
{
    public Car CreateCar(PedalEngineParams engineParams, Guid carId)
    {
        var engine = new PedalEngine(engineParams.PedalSize);
        return new Car(engine, carId);
    }
}