// Domain/Entities/Enclosure.cs
using Zoo.Domain.ValueObjects;

namespace Zoo.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: вольер для животных.
    /// </summary>
    public class Enclosure
    {
        public int Id { get; set; }  
        public string Name { get; private set; }
        public EnclosureType Type { get; private set; }
        public Dimensions Size { get; private set; }

        public Enclosure(string name, EnclosureType type, Dimensions size)
        {
            Name = name;
            Type = type;
            Size = size;
        }
    }
}