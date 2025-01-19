namespace ConsoleApp;

class FactoryAF
{
    private List<Car> Cars = new();
    private List<Customer> Customers = new();

    public void AddCar(int serialNumber, int pedalSize)
    {
        Cars.Add(new Car(serialNumber, pedalSize));
    }

    public void AddCustomer(string name)
    {
        Customers.Add(new Customer(name));
    }

    public void SaleCar()
    {
        foreach (var customer in Customers.Where(c => c.PurchasedCar == null))
        {
            if (Cars.Count > 0)
            {
                customer.PurchasedCar = Cars[0];
                Cars.RemoveAt(0);
            }
        }

        if (Cars.Count > 0)
        {
            Console.WriteLine("No more customers waiting. Remaining cars are being liquidated.");
            Cars.Clear();
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine("\nCars on stock:");
        if (Cars.Count == 0)
            Console.WriteLine("No cars available.");
        else
            Cars.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("\nCustomers:");
        Customers.ForEach(customer => Console.WriteLine(customer));
    }
}