using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Services;
using Zoo.Presentation.DTOs;

namespace Zoo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalsController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        // Добавление нового животного
        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalDto animalDto)
        {
            var animal = _animalService.AddAnimal(animalDto.Name, animalDto.Species,
                animalDto.Gender, animalDto.Status,
                animalDto.FoodType);
            return Ok(animal);
        }

        // Удаление животного по идентификатору
        [HttpDelete("{id}")]
        public IActionResult RemoveAnimal(int id)
        {
            bool removed = _animalService.RemoveAnimal(id);
            if (!removed)
                return NotFound();
            return NoContent();
        }

        // Получение списка всех животных
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            var animals = _animalService.GetAllAnimals();
            return Ok(animals);
        }

        // Получение животного по идентификатору
        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = _animalService.GetAnimal(id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }
    }
}