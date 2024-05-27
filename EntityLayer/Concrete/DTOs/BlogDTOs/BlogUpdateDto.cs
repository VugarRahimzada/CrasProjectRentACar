using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.DTOs.BlogDTOs
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
}
