using EntityLayer.Concrete.DTOs.CarDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.DTOs.BookingDTOs
{
    public class BookingReadDto
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

        public int Delete { get; set; } = 0;
    }
}
