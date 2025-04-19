using System.Collections.Generic;
using Zoo.Domain.Entities;
using Zoo.Domain.ValueObjects;
using Zoo.Application.Interfaces;

namespace Zoo.Application.Services
{
    /// <summary>
    /// Сервис для управления животными (добавление, удаление, получение).
    /// </summary>
    public class AnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Animal AddAnimal(string name, AnimalSpecies species,
            AnimalGender gender, AnimalStatus status,
            FoodType foodType)
        {
            var animal = new Animal(name, species, gender, status, foodType);
            return _animalRepository.Add(animal);
        }

        public bool RemoveAnimal(int animalId)
        {
            return _animalRepository.Remove(animalId);
        }

        public Animal GetAnimal(int animalId)
        {
            return _animalRepository.GetById(animalId);
        }

        public IEnumerable<Animal> GetAllAnimals()
        {
            return _animalRepository.GetAll();
        }
    }
}