using System.Collections.Generic;
using System.Linq;
using Zoo.Application.Interfaces;
using Zoo.Domain.Entities;

namespace Zoo.Infrastructure.Repositories
{
    /// <summary>
    /// Реализация репозитория животных в памяти.
    /// </summary>
    public class InMemoryAnimalRepository : IAnimalRepository
    {
        private static List<Animal> _animals = new List<Animal>();
        private static int _nextId = 1;

        public Animal Add(Animal animal)
        {
            animal.Id = _nextId++;
            _animals.Add(animal);
            return animal;
        }

        public bool Remove(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return false;
            _animals.Remove(animal);
            return true;
        }

        public Animal GetById(int id)
        {
            return _animals.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _animals;
        }

        public void Update(Animal animal)
        {
            var index = _animals.FindIndex(a => a.Id == animal.Id);
            if (index != -1)
            {
                _animals[index] = animal;
            }
        }
    }
}