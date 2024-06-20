using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BrandDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] BrandCreateDto brand)
        {
            var result = _brandService.Add(brand);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] BrandUpdateDto brand)
        {
            var result = _brandService.Update(brand);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _brandService.HardDelete(id);
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public IActionResult Delete(int id)
        {
            var result = _brandService.Delete(id);
            return Ok(result);
        }
    }
}
