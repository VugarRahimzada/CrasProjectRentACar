using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _aboutService.GetAll();
            return Ok(result); 
        }

        [HttpPost]
        public IActionResult Add([FromBody] AboutCreateDto aboutCreateDto)
        {
            var result = _aboutService.Add(aboutCreateDto);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] AboutUpdateDto about)
        {
            var result = _aboutService.Update(about);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _aboutService.Delete(id);
            return Ok(result);
        }

        [HttpDelete("HardDelete/{id}")]
        public IActionResult HardDelete(int id)
        {
            var result = _aboutService.HardDelete(id);
            return Ok(result);
        }
    }
}
