using ConsoleApp.Abstractions.Abstractions;

namespace ConsoleApp.Abstractions;

public class Car
{
    public Guid Number { get; }
    
    public IEngine Engine { get;}
    
    public Car(IEngine engine, Guid number)
    {
        ArgumentNullException.ThrowIfNull(engine, nameof(engine));

        Engine = engine;
        Number = number;
    }
    
    public bool IsCompatible(Customer customer) => Engine.IsCompatible(customer);
    
    public override string ToString() => $"Номер: {Number}, Двигатель: {{ {Engine} }}";


    
}