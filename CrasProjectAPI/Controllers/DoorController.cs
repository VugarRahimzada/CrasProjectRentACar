using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.DoorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoorController : ControllerBase
    {
        private readonly IDoorService _doorService;

        public DoorController(IDoorService doorService)
        {
            _doorService = doorService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _doorService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] DoorCreateDto door)
        {
            var result = _doorService.Add(door);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] DoorUpdateDto door)
        {
            var result = _doorService.Update(door);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _doorService.HardDelete(id);
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public IActionResult Delete(int id)
        {
            var result = _doorService.Delete(id);
            return Ok(result);
        }
    }
}
