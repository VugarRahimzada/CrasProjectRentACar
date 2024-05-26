using EntityLayer.Concrete.DTOs.CommentDTOs;

namespace EntityLayer.Concrete.DTOs.BlogDTOs
{
    public class BlogReadWithCommentsDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentCounta { get; set; } = 0;
        public string PhotoPath { get; set; }
        public DateTime CreateDate { get; set; }
        public List<CommentReadDto> Comments { get; set; }
    }
}
