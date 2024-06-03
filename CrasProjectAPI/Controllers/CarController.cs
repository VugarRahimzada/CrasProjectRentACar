using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.CarDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        //[Authorize(Roles = "User")]

        [HttpGet("Active")]
        public IActionResult GetAllActive()
        {
            var result = _carService.GetAllActive();
            return Ok(result);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] CarCreateDTO car)
        {    
            var result = _carService.Add(car);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update([FromForm] CarUpdateDto car)
        {

            var result = _carService.Update(car);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _carService.HardDelete(id);
            return Ok(result);
        }
        [HttpPut("SoftDelete")]
        public IActionResult Delete(int ID)
        {
            var result = _carService.Delete(ID);
            return Ok(result);
        }
    }
}
