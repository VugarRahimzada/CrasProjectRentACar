using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Door : BaseEntity
    {
        public Door()
        {
            Cars = new HashSet<Car>();
        }
        public int DoorCount { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
