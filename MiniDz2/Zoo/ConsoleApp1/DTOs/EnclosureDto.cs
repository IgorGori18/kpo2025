using Zoo.Domain.ValueObjects;

namespace Zoo.Presentation.DTOs
{
    /// <summary>
    /// DTO для создания нового вольера.
    /// </summary>
    public class EnclosureDto
    {
        public string Name { get; set; }
        public EnclosureType Type { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}