using ConsoleApp.Abstractions.Abstractions;

namespace ConsoleApp.Abstractions;

public class HandEngine : IEngine
{
    public HandEngine() { }

    public bool IsCompatible(Customer customer) => customer.HandStrength > 5;
    
    public override string ToString() => "Тип: ручной привод";
    
    
}