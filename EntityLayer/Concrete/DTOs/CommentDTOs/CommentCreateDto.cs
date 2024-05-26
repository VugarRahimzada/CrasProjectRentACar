namespace EntityLayer.Concrete.DTOs.CommentDTOs
{
    public class CommentCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
