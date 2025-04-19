using System;

namespace Zoo.Domain.Events
{
    /// <summary>
    /// Доменное событие: время кормления наступило (кормление выполнено).
    /// </summary>
    public class FeedingTimeEvent : DomainEvent
    {
        public int FeedingScheduleId { get; }
        public int AnimalId { get; }
        public DateTime ScheduledTime { get; }

        public FeedingTimeEvent(int feedingScheduleId, int animalId, DateTime scheduledTime)
        {
            FeedingScheduleId = feedingScheduleId;
            AnimalId = animalId;
            ScheduledTime = scheduledTime;
        }

        public override string ToString()
        {
            return $"FeedingTimeEvent: Animal {AnimalId} scheduled at {ScheduledTime} fed at {OccurredAt}.";
        }
    }
}