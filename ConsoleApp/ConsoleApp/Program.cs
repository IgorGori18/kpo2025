namespace ConsoleApp;
class Program
{
    static void Main(string[] args)
    {
        var factory = new FactoryAF();

        factory.AddCar(1, 42);
        factory.AddCar(2, 44);
        factory.AddCar(3, 40);

        factory.AddCustomer("Nikolay");
        factory.AddCustomer("Matvey");
        factory.AddCustomer("Marek");

        Console.WriteLine("Before SaleCar():");
        factory.DisplayStatus();

        factory.SaleCar();

        Console.WriteLine("\nAfter SaleCar():");
        factory.DisplayStatus();
    }
}