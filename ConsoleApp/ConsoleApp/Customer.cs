namespace ConsoleApp;

public class Customer
{
    public string Name { get; }
    public Car PurchasedCar { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return PurchasedCar == null ? $"Customer {Name} is waiting for a car." : $"Customer {Name} owns {PurchasedCar}.";
    }
}