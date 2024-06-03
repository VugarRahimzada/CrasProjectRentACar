using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
