using ConsoleApp.Abstractions;
using ConsoleApp.Abstractions.Abstractions;

namespace ConsoleApp.Services.Abstractions;

public interface ICarFactory<TParams> where TParams : EngineParamsBase
{
    Car CreateCar(TParams engineParams, Guid numberOfCar);
}