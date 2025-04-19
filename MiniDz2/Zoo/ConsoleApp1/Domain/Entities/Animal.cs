using Zoo.Domain.ValueObjects;

namespace Zoo.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: животное.
    /// </summary>
    public class Animal
    {
        public int Id { get; set; }  
        public string Name { get; private set; }
        public AnimalSpecies Species { get; private set; }
        public AnimalGender Gender { get; private set; }
        public AnimalStatus Status { get; private set; }
        public FoodType FoodType { get; private set; }
        public int? EnclosureId { get; private set; }

        public Animal(string name, AnimalSpecies species, AnimalGender gender,
            AnimalStatus status, FoodType foodType, int? enclosureId = null)
        {
            Name = name;
            Species = species;
            Gender = gender;
            Status = status;
            FoodType = foodType;
            EnclosureId = enclosureId;
        }

        /// <summary>
        /// Перемещение животного в другой вольер.
        /// </summary>
        public void MoveToEnclosure(int? newEnclosureId)
        {
            if (EnclosureId == newEnclosureId) return; 
            var oldEnclosureId = EnclosureId;
            EnclosureId = newEnclosureId;
            
        }
    }
}