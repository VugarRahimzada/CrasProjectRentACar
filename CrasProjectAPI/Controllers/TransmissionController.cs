using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.TransmissionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly ITransmissionService _transmissionService;

        public TransmissionController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _transmissionService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] TransmissionCreateDto transmission)
        {
            var result = _transmissionService.Add(transmission);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] TransmissionUpdateDto transmission)
        {
            var result = _transmissionService.Update(transmission);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _transmissionService.HardDelete(id);
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public IActionResult Delete(int id)
        {
            var result = _transmissionService.Delete(id);
            return Ok(result);
        }
    }
}
