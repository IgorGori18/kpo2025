using System.Collections.Generic;
using Zoo.Domain.Entities;

namespace Zoo.Application.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория животных.
    /// </summary>
    public interface IAnimalRepository
    {
        Animal Add(Animal animal);
        bool Remove(int id);
        Animal GetById(int id);
        IEnumerable<Animal> GetAll();
        void Update(Animal animal);
    }
}