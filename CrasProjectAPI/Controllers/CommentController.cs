using BusinessLayer.Abstract;
using BusinessLayer.Validation.FluentValidation;
using CoreLayer.Results.Concrete;
using EntityLayer.Concrete.DTOs.CommentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
       

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("Active")]
        public IActionResult GetAllActive()
        {
            var result = _commentService.GetAllActive();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _commentService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetCommentByBlogId")]
        public IActionResult GetCommentByBlogId(int id)
        {
            var result = _commentService.GetCommentsByBlogId(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CommentCreateDto comment)
        {
            var result =  _commentService.Add(comment);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _commentService.HardDelete(id);
            return Ok(result);
        }
        [HttpPut("SoftDelete")]
        public IActionResult Delete(int ID)
        {
            var result =_commentService.Delete(ID);
            return Ok(result);
        }

    }
}
