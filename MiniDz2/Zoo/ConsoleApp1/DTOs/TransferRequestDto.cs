namespace Zoo.Presentation.DTOs
{
    /// <summary>
    /// DTO для запроса перемещения животного.
    /// </summary>
    public class TransferRequestDto
    {
        public int AnimalId { get; set; }
        public int TargetEnclosureId { get; set; }
    }
}