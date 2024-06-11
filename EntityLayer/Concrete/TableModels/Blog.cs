using CoreLayer.Entities;
using EntityLayer.Concrete.TableModels.Membership;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace EntityLayer.Concrete.TableModels
{
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentCounta { get; set; } = 0;
        public string Author {  get; set; }
        public string PhotoPath { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
