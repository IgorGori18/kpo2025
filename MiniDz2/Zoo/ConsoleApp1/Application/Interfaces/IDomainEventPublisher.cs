using Zoo.Domain.Events;

namespace Zoo.Application.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса публикации доменных событий.
    /// </summary>
    public interface IDomainEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}