using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Brand : BaseEntity
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }
        public string BrandName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
