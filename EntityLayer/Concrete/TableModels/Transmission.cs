using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Transmission :BaseEntity
    {
        public Transmission()
        {
            Cars = new HashSet<Car>();
        }
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
