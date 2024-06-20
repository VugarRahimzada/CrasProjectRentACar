using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.FuelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuelController : ControllerBase
    {
        private readonly IFuelService _fuelService;

        public FuelController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _fuelService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] FuelCreateDto fuel)
        {
            var result = _fuelService.Add(fuel);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] FuelUpdateDto fuel)
        {
            var result = _fuelService.Update(fuel);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _fuelService.HardDelete(id);
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public IActionResult Delete(int id)
        {
            var result = _fuelService.Delete(id);
            return Ok(result);
        }
    }
}
