using System.Linq;
using Zoo.Application.Interfaces;

namespace Zoo.Application.Services
{
    /// <summary>
    /// Сервис для получения статистических данных зоопарка.
    /// </summary>
    public class ZooStatisticsService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IEnclosureRepository _enclosureRepository;

        public ZooStatisticsService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
        }

        public ZooStatisticsDto GetStatistics()
        {
            int totalAnimals = _animalRepository.GetAll().Count();
            int occupiedEnclosures = _animalRepository.GetAll()
                .Where(a => a.EnclosureId.HasValue)
                .Select(a => a.EnclosureId.Value)
                .Distinct()
                .Count();
            int totalEnclosures = _enclosureRepository.GetAll().Count();
            int freeEnclosures = totalEnclosures - occupiedEnclosures;
            return new ZooStatisticsDto(totalAnimals, freeEnclosures);
        }
    }
}