using System;

namespace Zoo.Domain.Events
{
    /// <summary>
    /// Базовый класс для доменных событий.
    /// </summary>
    public abstract class DomainEvent
    {
        public DateTime OccurredAt { get; protected set; }

        protected DomainEvent()
        {
            OccurredAt = DateTime.Now;
        }
    }
}