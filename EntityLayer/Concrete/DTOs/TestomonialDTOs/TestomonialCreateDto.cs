using Microsoft.AspNetCore.Http;

namespace EntityLayer.Concrete.DTOs.TestomonialDTOs
{
    public class TestomonialCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public IFormFile PhotoPath { get; set; }
        public string LinkedIn { get; set; }
    }
}
