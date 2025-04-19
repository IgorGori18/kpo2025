using System.Collections.Generic;
using Zoo.Domain.Entities;
using Zoo.Application.Interfaces;
using Zoo.Domain.ValueObjects;

namespace Zoo.Application.Services
{
    /// <summary>
    /// Сервис для управления вольерами (добавление, удаление, получение).
    /// </summary>
    public class EnclosureService
    {
        private readonly IEnclosureRepository _enclosureRepository;
        private readonly IAnimalRepository _animalRepository;

        public EnclosureService(IEnclosureRepository enclosureRepository, IAnimalRepository animalRepository)
        {
            _enclosureRepository = enclosureRepository;
            _animalRepository = animalRepository;
        }

        public Enclosure AddEnclosure(string name, EnclosureType type, Dimensions size)
        {
            var enclosure = new Enclosure(name, type, size);
            return _enclosureRepository.Add(enclosure);
        }

        public bool RemoveEnclosure(int enclosureId)
        {
            foreach (var animal in _animalRepository.GetAll())
            {
                if (animal.EnclosureId == enclosureId)
                {
                    return false;
                }
            }
            return _enclosureRepository.Remove(enclosureId);
        }

        public Enclosure GetEnclosure(int enclosureId)
        {
            return _enclosureRepository.GetById(enclosureId);
        }

        public IEnumerable<Enclosure> GetAllEnclosures()
        {
            return _enclosureRepository.GetAll();
        }
    }
}