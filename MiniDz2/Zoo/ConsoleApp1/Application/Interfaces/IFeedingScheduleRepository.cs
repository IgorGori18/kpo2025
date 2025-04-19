using System.Collections.Generic;
using Zoo.Domain.Entities;

namespace Zoo.Application.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория расписания кормлений.
    /// </summary>
    public interface IFeedingScheduleRepository
    {
        FeedingSchedule Add(FeedingSchedule scheduleEntry);
        FeedingSchedule GetById(int id);
        IEnumerable<FeedingSchedule> GetAll();
        void Update(FeedingSchedule scheduleEntry);
    }
}