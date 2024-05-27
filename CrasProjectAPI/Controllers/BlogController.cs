using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlogService blogService, IWebHostEnvironment webHostEnvironment)
        {
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Active")]
        public IActionResult GetAllActive()
        {
            var result = _blogService.GetAllActive();
            return Ok(result);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _blogService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] BlogCreateDto blog)
        {
            var result = _blogService.Add(blog,_webHostEnvironment.WebRootPath);
            return Ok(result);
        }


        [HttpPut]
        public IActionResult Update([FromBody] BlogUpdateDto blog)
        {

            var result = _blogService.Update(blog);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _blogService.HardDelete(id);
            return Ok(result);
        }
        [HttpPut("SoftDelete")]
        public IActionResult Delete(int ID)
        {
            var result = _blogService.Delete(ID);
            return Ok(result);
        }

    }
}
