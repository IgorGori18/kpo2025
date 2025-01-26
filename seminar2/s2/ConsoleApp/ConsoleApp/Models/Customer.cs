namespace ConsoleApp.Abstractions;

public class Customer
{
    public string Name { get; }
    public uint HandStrength { get; }
    public uint LegStrength { get; }
    public Car? Car { get; set; }

    public Customer(string name, uint legStrength, uint handStrength)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        Name = name;
        LegStrength = legStrength;
        HandStrength = handStrength;
    }

    public override string ToString()
    {
        if (Car is null) 
        {
            return $"Имя: {Name}, Сила ног: {LegStrength}, Сила рук: {HandStrength}, Автомобиль: Нет";
        }

        return $"Имя: {Name}, Сила ног: {LegStrength}, Сила рук: {HandStrength},\n" + $"Автомобиль: {{ {Car} }}";
    }
    
    
}