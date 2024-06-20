using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using EntityLayer.Concrete.DTOs.TestomonialDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestomonialController : ControllerBase
    {
        private readonly ITestomonialService _testomonialService;

        public TestomonialController(ITestomonialService testomonialService)
        {
            _testomonialService = testomonialService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _testomonialService.GetAll();
            return Ok(result);
        }
        [HttpGet("AllActive")]
        public IActionResult GetAllActive()
        {
            var result = _testomonialService.GetAllActive();
            return Ok(result);
        }

        [HttpPost("Crate")]
        public IActionResult Create( [FromForm] TestomonialCreateDto testomonial)
        {
            var result = _testomonialService.Add(testomonial);
            return Ok(result);
        }

 

        [HttpPut("Update")]
        public IActionResult Update([FromForm] TestomonialUpdateDto testomonial)
        {
            var result = _testomonialService.Update(testomonial);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult HardDelete(int id)
        {
            var result = _testomonialService.HardDelete(id);
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public IActionResult Delete(int id)
        {
            var result = _testomonialService.Delete(id);
            return Ok(result);
        }
    }
}
