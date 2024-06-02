using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Booking : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Request { get; set; }
        public bool IsTaked { get; set; } = false;

        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public string PickUpLocation { get; set; }
        public string Destination { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
