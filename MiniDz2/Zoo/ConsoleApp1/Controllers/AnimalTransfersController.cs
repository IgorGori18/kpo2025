using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Services;
using Zoo.Presentation.DTOs;

namespace Zoo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalTransfersController : ControllerBase
    {
        private readonly AnimalTransferService _transferService;

        public AnimalTransfersController(AnimalTransferService transferService)
        {
            _transferService = transferService;
        }

        // Перемещение животного в другой вольер
        [HttpPost]
        public IActionResult TransferAnimal([FromBody] TransferRequestDto request)
        {
            bool transferred = _transferService.TransferAnimal(request.AnimalId, request.TargetEnclosureId);
            if (!transferred)
            {
                return BadRequest("Transfer failed. Ensure the IDs are correct and the target enclosure is free.");
            }
            return Ok("Animal transferred successfully.");
        }
    }
}