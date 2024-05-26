namespace EntityLayer.Concrete.DTOs.CommentDTOs
{
    public class CommentReadActiveDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
