using System;
using Zoo.Application.Interfaces;
using Zoo.Domain.Events;

namespace Zoo.Infrastructure.Events
{
    /// <summary>
    /// Простой паблишер доменных событий, выводящий события в консоль.
    /// </summary>
    public class ConsoleDomainEventPublisher : IDomainEventPublisher
    {
        public void Publish(DomainEvent domainEvent)
        {
            Console.WriteLine($"Domain event published: {domainEvent}");
        }
    }
}