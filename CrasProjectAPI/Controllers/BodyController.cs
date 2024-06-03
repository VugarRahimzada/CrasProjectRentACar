using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BodyDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {
        private readonly IBodyService _bodyService;

        public BodyController(IBodyService bodyService)
        {
            _bodyService = bodyService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _bodyService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] BodyCreateDto body)
        {
            var result = _bodyService.Add(body);
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update([FromForm] BodyUpdateDto body)
        {

            var result = _bodyService.Update(body);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result =_bodyService.HardDelete(id);
            return Ok(result);
        }
        [HttpPut("SoftDelete")]
        public IActionResult Delete(int ID)
        {
            var result = _bodyService.Delete(ID);
            return Ok(result);
        }
    }
}
