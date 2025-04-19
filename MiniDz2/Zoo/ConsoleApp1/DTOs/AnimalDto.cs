using Zoo.Domain.ValueObjects;

namespace Zoo.Presentation.DTOs
{
    /// <summary>
    /// DTO для создания животного.
    /// </summary>
    public class AnimalDto
    {
        public string Name { get; set; }
        public AnimalSpecies Species { get; set; }
        public AnimalGender Gender { get; set; }
        public AnimalStatus Status { get; set; }
        public FoodType FoodType { get; set; }
    }
}