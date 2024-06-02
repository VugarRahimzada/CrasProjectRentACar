using EntityLayer.Concrete.DTOs.CarDTOs;

namespace EntityLayer.Concrete.DTOs.BookingDTOs
{
    public class BookingConfirmationDto
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

        public CarWaitingListDto Car { get; set; }
    }
}
