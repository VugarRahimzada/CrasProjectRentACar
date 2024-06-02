using EntityLayer.Concrete.TableModels;

namespace EntityLayer.Concrete.DTOs.BookingDTOs
{
    public class BookingCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Request { get; set; }

        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public string PickUpLocation { get; set; }
        public string Destination { get; set; }

        public int CarId { get; set; }
    }
}
