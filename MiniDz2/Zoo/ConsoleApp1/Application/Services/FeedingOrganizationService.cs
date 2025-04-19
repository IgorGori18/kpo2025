using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Application.Interfaces;
using Zoo.Domain.Entities;
using Zoo.Domain.Events;

namespace Zoo.Application.Services
{
    /// <summary>
    /// Сервис для организации кормления животных (управление расписанием кормлений).
    /// </summary>
    public class FeedingOrganizationService
    {
        private readonly IFeedingScheduleRepository _feedingRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IDomainEventPublisher _eventPublisher;

        public FeedingOrganizationService(IFeedingScheduleRepository feedingRepository,
                                          IAnimalRepository animalRepository,
                                          IDomainEventPublisher eventPublisher)
        {
            _feedingRepository = feedingRepository;
            _animalRepository = animalRepository;
            _eventPublisher = eventPublisher;
        }

        public FeedingSchedule ScheduleFeeding(int animalId, DateTime feedingTime)
        {
            var animal = _animalRepository.GetById(animalId);
            if (animal == null) return null;
            var entry = new FeedingSchedule(animalId, feedingTime);
            _feedingRepository.Add(entry);
            return entry;
        }

        public IEnumerable<FeedingSchedule> GetFeedingSchedule(bool includeCompleted = false)
        {
            var allEntries = _feedingRepository.GetAll();
            if (includeCompleted)
                return allEntries;
            return allEntries.Where(entry => !entry.IsCompleted);
        }

        public bool MarkFeedingAsCompleted(int feedingScheduleId)
        {
            var entry = _feedingRepository.GetById(feedingScheduleId);
            if (entry == null) return false;
            entry.MarkCompleted();
            _feedingRepository.Update(entry);
            var evt = new FeedingTimeEvent(entry.Id, entry.AnimalId, entry.ScheduledTime);
            _eventPublisher.Publish(evt);
            return true;
        }
    }
}
