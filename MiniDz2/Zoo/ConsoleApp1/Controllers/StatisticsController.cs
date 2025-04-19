using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Services;

namespace Zoo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ZooStatisticsService _statisticsService;

        public StatisticsController(ZooStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        // Получение статистики зоопарка
        [HttpGet]
        public IActionResult GetStatistics()
        {
            var stats = _statisticsService.GetStatistics();
            return Ok(stats);
        }
    }
}