namespace Zoo.Application.Services
{
    /// <summary>
    /// DTO для представления статистики зоопарка.
    /// </summary>
    public record ZooStatisticsDto(int TotalAnimals, int FreeEnclosures);
}