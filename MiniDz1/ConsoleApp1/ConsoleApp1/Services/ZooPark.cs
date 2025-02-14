using System;
using System.Collections.Generic;
using System.Linq;
using ZooERP.Domain;
using ZooERP.Inventory;
using ZooERP.Services;

namespace ZooERP.Zoo
{
    public class ZooPark : IZoo
    {
        public List<Animal> Animals { get; } = new List<Animal>();
        public List<Thing> Things { get; } = new List<Thing>();

        private readonly IVetClinic _vetClinic;

        public ZooPark(IVetClinic vetClinic)
        {
            _vetClinic = vetClinic;
        }

        public bool AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckAnimal(animal))
            {
                Animals.Add(animal);
                Console.WriteLine($"Животное '{animal.Name}' принято в зоопарк.");
                return true;
            }
            else
            {
                Console.WriteLine($"Животное '{animal.Name}' отклонено ветеринарной клиникой.");
                return false;
            }
        }

        public void AddThing(Thing thing)
        {
            Things.Add(thing);
        }

        public int GetTotalFood()
        {
            return Animals.Sum(a => a.Food);
        }

        public IEnumerable<Animal> GetContactZooAnimals()
        {
            // Предположим, что для контактного зоопарка подходят только травоядные, которые могут интерактивно взаимодействовать
            return Animals.OfType<Herbo>().Where(h => h.CanInteract).Cast<Animal>();
        }

        public IEnumerable<IInventory> GetAllInventory()
        {
            // Предположим, что и животные, и вещи участвуют в инвентаризации, поскольку оба типа реализуют IInventory
            return Animals.Cast<IInventory>().Concat(Things);
        }

        // Если требуется, можно оставить метод PrintInventory() как вспомогательный, но он не входит в интерфейс
        public void PrintInventory()
        {
            Console.WriteLine("\nИнвентаризация зоопарка:");
            foreach (var animal in Animals)
            {
                Console.WriteLine($"Животное: {animal.Name}, Инвентарный номер: {animal.Number}");
            }
            foreach (var thing in Things)
            {
                Console.WriteLine($"Вещь: {thing.Name}, Инвентарный номер: {thing.Number}");
            }
        }
    }
}
