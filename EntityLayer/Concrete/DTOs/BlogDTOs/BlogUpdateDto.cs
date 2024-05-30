using Microsoft.AspNetCore.Http;

namespace EntityLayer.Concrete.DTOs.BlogDTOs
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile? PhotoPath { get; set; }
    }
}
