using System;

namespace Zoo.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: запись расписания кормления.
    /// </summary>
    public class FeedingSchedule
    {
        public int Id { get; set; }  
        public int AnimalId { get; private set; }
        public DateTime ScheduledTime { get; private set; }
        public bool IsCompleted { get; private set; }

        public FeedingSchedule(int animalId, DateTime scheduledTime)
        {
            AnimalId = animalId;
            ScheduledTime = scheduledTime;
            IsCompleted = false;
        }

        /// <summary>
        /// Отметить данное кормление как выполненное.
        /// </summary>
        public void MarkCompleted()
        {
            IsCompleted = true;
        }
    }
}