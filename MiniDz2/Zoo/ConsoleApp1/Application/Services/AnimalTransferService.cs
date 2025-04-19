using System.Linq;
using Zoo.Application.Interfaces;
using Zoo.Domain.Entities;
using Zoo.Domain.Events;

namespace Zoo.Application.Services
{
    /// <summary>
    /// Сервис для перемещения животных между вольерами.
    /// </summary>
    public class AnimalTransferService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IEnclosureRepository _enclosureRepository;
        private readonly IDomainEventPublisher _eventPublisher;

        public AnimalTransferService(IAnimalRepository animalRepository,
                                     IEnclosureRepository enclosureRepository,
                                     IDomainEventPublisher eventPublisher)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
            _eventPublisher = eventPublisher;
        }

        public bool TransferAnimal(int animalId, int targetEnclosureId)
        {
            var animal = _animalRepository.GetById(animalId);
            if (animal == null) return false;
            var targetEnclosure = _enclosureRepository.GetById(targetEnclosureId);
            if (targetEnclosure == null) return false;
            bool occupied = _animalRepository.GetAll().Any(a => a.EnclosureId == targetEnclosureId);
            if (occupied) return false;
            var oldEnclosureId = animal.EnclosureId;
            if (oldEnclosureId == targetEnclosureId)
            {
                return true; 
            }
            animal.MoveToEnclosure(targetEnclosureId);
            _animalRepository.Update(animal);
            var evt = new AnimalMovedEvent(animal.Id, oldEnclosureId, targetEnclosureId);
            _eventPublisher.Publish(evt);
            return true;
        }
    }
}
