using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
