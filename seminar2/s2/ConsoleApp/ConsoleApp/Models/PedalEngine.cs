using ConsoleApp.Abstractions.Abstractions;

namespace ConsoleApp.Abstractions;

public class PedalEngine : IEngine
{
    public uint Size { get; }

    public PedalEngine(uint size) => Size = size;
    
    public bool IsCompatible(Customer customer) => customer.LegStrength > 5;
    
    public override string ToString() => "Тип: педальный привод";

    
    
}