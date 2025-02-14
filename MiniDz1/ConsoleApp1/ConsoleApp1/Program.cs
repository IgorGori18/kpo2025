using System;
using Microsoft.Extensions.DependencyInjection;
using ZooERP.Domain;
using ZooERP.Zoo;
using ZooERP.Services;
using ZooERP.Inventory;

namespace ZooERP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка DI-контейнера
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IVetClinic, VetClinic>()
                .AddSingleton<IZoo, ZooPark>() 
                .BuildServiceProvider();

            
            var zoo = serviceProvider.GetService<IZoo>();

            Animal rabbit = new Rabbit { Name = "Марек", Food = 2, Number = 101, Kindness = 7 };
            Animal tiger = new Tiger { Name = "Аизен", Food = 10, Number = 102 };
            Animal monkey = new Monkey { Name = "Ле", Food = 3, Number = 103 };

            zoo.AddAnimal(rabbit);
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(monkey);

            // Пример добавления вещей
            zoo.AddThing(new Table { Name = "Стол", Number = 201 });
            zoo.AddThing(new Computer { Name = "Компьютер", Number = 202 });

            Console.WriteLine($"\nОбщее потребление еды: {zoo.GetTotalFood()} кг в день");

            Console.WriteLine("\nЖивотные для контактного зоопарка:");
            
            foreach (var animal in zoo.GetContactZooAnimals())
            {
                Console.WriteLine($"- {animal.Name}");
            }

            if (zoo is ZooPark concreteZoo)
            {
                concreteZoo.PrintInventory();
            }

        }
    }
}
