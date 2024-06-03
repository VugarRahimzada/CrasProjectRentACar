﻿using Microsoft.AspNetCore.Http;

namespace EntityLayer.Concrete.DTOs.BlogDTOs
{
    public class BlogCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
}
