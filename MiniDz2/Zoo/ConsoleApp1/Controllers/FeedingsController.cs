using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Services;
using Zoo.Presentation.DTOs;
using Zoo.Domain.Entities;

namespace Zoo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedingsController : ControllerBase
    {
        private readonly FeedingOrganizationService _feedingService;

        public FeedingsController(FeedingOrganizationService feedingService)
        {
            _feedingService = feedingService;
        }

        // Планирование нового кормления
        [HttpPost]
        public IActionResult ScheduleFeeding([FromBody] FeedingDto feedingDto)
        {
            var entry = _feedingService.ScheduleFeeding(feedingDto.AnimalId, feedingDto.ScheduledTime);
            if (entry == null)
            {
                return NotFound("Animal not found");
            }
            return Ok(entry);
        }

        // Просмотр расписания кормлений
        [HttpGet]
        public IActionResult GetFeedingSchedule([FromQuery] bool includeCompleted = false)
        {
            var schedule = _feedingService.GetFeedingSchedule(includeCompleted);
            return Ok(schedule);
        }

        // Отметить кормление выполненным
        [HttpPost("{id}/complete")]
        public IActionResult CompleteFeeding(int id)
        {
            bool success = _feedingService.MarkFeedingAsCompleted(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}