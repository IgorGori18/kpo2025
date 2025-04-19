using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Services;
using Zoo.Presentation.DTOs;
using Zoo.Domain.Entities;
using Zoo.Domain.ValueObjects;

namespace Zoo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosuresController : ControllerBase
    {
        private readonly EnclosureService _enclosureService;

        public EnclosuresController(EnclosureService enclosureService)
        {
            _enclosureService = enclosureService;
        }

        // Добавление нового вольера
        [HttpPost]
        public IActionResult AddEnclosure([FromBody] EnclosureDto enclosureDto)
        {
            var size = new Dimensions(enclosureDto.Width, enclosureDto.Length);
            var enclosure = _enclosureService.AddEnclosure(enclosureDto.Name, enclosureDto.Type, size);
            return Ok(enclosure);
        }

        // Удаление вольера
        [HttpDelete("{id}")]
        public IActionResult RemoveEnclosure(int id)
        {
            var enclosure = _enclosureService.GetEnclosure(id);
            if (enclosure == null)
                return NotFound();
            bool removed = _enclosureService.RemoveEnclosure(id);
            if (!removed)
            {
                return BadRequest("Cannot remove enclosure: it is not empty.");
            }
            return NoContent();
        }

        // Просмотр всех вольеров
        [HttpGet]
        public IActionResult GetAllEnclosures()
        {
            var enclosures = _enclosureService.GetAllEnclosures();
            return Ok(enclosures);
        }

        // Просмотр конкретного вольера по ID
        [HttpGet("{id}")]
        public IActionResult GetEnclosureById(int id)
        {
            var enclosure = _enclosureService.GetEnclosure(id);
            if (enclosure == null)
                return NotFound();
            return Ok(enclosure);
        }
    }
}
