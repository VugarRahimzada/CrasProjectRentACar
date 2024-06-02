using EntityLayer.Concrete.DTOs.BodyDTOs;
using EntityLayer.Concrete.DTOs.BrandDTOs;
using EntityLayer.Concrete.DTOs.DoorDTOs;
using EntityLayer.Concrete.DTOs.FuelDTOs;
using EntityLayer.Concrete.DTOs.TransmissionDTOs;

namespace EntityLayer.Concrete.DTOs.CarDTOs
{
    public class CarWaitingListDto
    {
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public double Kilometer { get; set; }
        public string ExteriorColor { get; set; }
        public string PhotoPath { get; set; }
    }
}
