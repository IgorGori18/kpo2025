using ConsoleApp.Abstractions;
using ConsoleApp.Abstractions.Abstractions;
using ConsoleApp.Services;
using ConsoleApp.Services.Abstractions;

internal class Program
{
    public static void Main(string[] args)
    {
        var carService = new CarService();
        var customerStorage = new CustomersStorage();
        var hseCarService = new HseCarService(carService, customerStorage);
        var pedalCarFactory = new PedalCarFactory();
        var handCarFactory = new HandCarFactory();

        customerStorage.AddCustomer(new Customer("Marko", 7, 5));
        customerStorage.AddCustomer(new Customer("Nikolay", 4, 6));
        customerStorage.AddCustomer(new Customer("Petar", 7, 5));
        customerStorage.AddCustomer(new Customer("Hasbula", 5, 5));

        carService.AddCar(pedalCarFactory, new PedalEngineParams(5));
        carService.AddCar(handCarFactory, new EmptyEngineParams());
        carService.AddCar(pedalCarFactory, new PedalEngineParams(5));
        carService.AddCar(handCarFactory, new EmptyEngineParams());

        Console.WriteLine("=== Покупатели (before) ===");
        foreach (var customer in customerStorage.GetCustomers())
            Console.WriteLine(customer);

        Console.WriteLine("\n=== Список автомобилей в наличии (before) ===");
        foreach (var car in carService.GetAllCars())
            Console.WriteLine(car);

        Console.WriteLine("\n=== Продажа автомобилей ===\n");
        hseCarService.SellCars();

        Console.WriteLine("=== Покупатели (after) ===");
        foreach (var customer in customerStorage.GetCustomers())
            Console.WriteLine(customer);

        Console.WriteLine("\n=== Список автомобилей в наличии (after) ===");
        foreach (var car in carService.GetAllCars())
            Console.WriteLine(car);

        
        
        
    }
}