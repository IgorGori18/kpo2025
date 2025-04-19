using System.Collections.Generic;
using System.Linq;
using Zoo.Application.Interfaces;
using Zoo.Domain.Entities;

namespace Zoo.Infrastructure.Repositories
{
    /// <summary>
    /// Реализация репозитория расписания кормлений в памяти.
    /// </summary>
    public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
    {
        private static List<FeedingSchedule> _feedings = new List<FeedingSchedule>();
        private static int _nextId = 1;

        public FeedingSchedule Add(FeedingSchedule scheduleEntry)
        {
            scheduleEntry.Id = _nextId++;
            _feedings.Add(scheduleEntry);
            return scheduleEntry;
        }

        public FeedingSchedule GetById(int id)
        {
            return _feedings.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FeedingSchedule> GetAll()
        {
            return _feedings;
        }

        public void Update(FeedingSchedule scheduleEntry)
        {
            var index = _feedings.FindIndex(f => f.Id == scheduleEntry.Id);
            if (index != -1)
            {
                _feedings[index] = scheduleEntry;
            }
        }
    }
}