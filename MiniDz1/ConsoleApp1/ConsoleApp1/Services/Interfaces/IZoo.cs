using System.Collections.Generic;
using ZooERP.Domain;
using ZooERP.Inventory;

namespace ZooERP.Zoo
{
    public interface IZoo
    {
        bool AddAnimal(Animal animal);
        void AddThing(Thing thing);
        int GetTotalFood();
        IEnumerable<Animal> GetContactZooAnimals();
        IEnumerable<IInventory> GetAllInventory();
    }
}