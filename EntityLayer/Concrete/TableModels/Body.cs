using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Body : BaseEntity
    {
        public Body()
        {
            Cars = new HashSet<Car>();
        }
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
