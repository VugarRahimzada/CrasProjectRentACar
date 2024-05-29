using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Fuel : BaseEntity
    {
        public Fuel()
        {
            Cars = new HashSet<Car>();
        }
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
