using System;

namespace Zoo.Presentation.DTOs
{
    /// <summary>
    /// DTO для планирования кормления.
    /// </summary>
    public class FeedingDto
    {
        public int AnimalId { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}