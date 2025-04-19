namespace Zoo.Domain.Events
{
    /// <summary>
    /// Доменное событие: животное перемещено между вольерами.
    /// </summary>
    public class AnimalMovedEvent : DomainEvent
    {
        public int AnimalId { get; }
        public int? FromEnclosureId { get; }
        public int? ToEnclosureId { get; }

        public AnimalMovedEvent(int animalId, int? fromEnclosureId, int? toEnclosureId)
        {
            AnimalId = animalId;
            FromEnclosureId = fromEnclosureId;
            ToEnclosureId = toEnclosureId;
        }

        public override string ToString()
        {
            string fromId = FromEnclosureId.HasValue ? FromEnclosureId.Value.ToString() : "None";
            string toId = ToEnclosureId.HasValue ? ToEnclosureId.Value.ToString() : "None";
            return $"AnimalMovedEvent: Animal {AnimalId} from Enclosure {fromId} to {toId} at {OccurredAt}.";
        }
    }
}