using EntityLayer.Concrete.DTOs.CommentDTOs;
using EntityLayer.Concrete.TableModels;

namespace EntityLayer.Concrete.DTOs.BlogDTOs
{
    public class BlogReadActivDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentCounta { get; set; } = 0;
        public string PhotoPath { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public List<CommentReadActiveDto> Comments { get; set; }
    }
}
