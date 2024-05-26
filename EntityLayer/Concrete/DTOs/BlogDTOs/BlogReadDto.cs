namespace EntityLayer.Concrete.DTOs.BlogDTOs
{
    public class BlogReadDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentCounta { get; set; } = 0;
        public string PhotoPath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
