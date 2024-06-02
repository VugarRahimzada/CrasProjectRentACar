using EntityLayer.Concrete.DTOs.BodyDTOs;
using EntityLayer.Concrete.DTOs.BrandDTOs;
using EntityLayer.Concrete.DTOs.DoorDTOs;
using EntityLayer.Concrete.DTOs.FuelDTOs;
using EntityLayer.Concrete.DTOs.TransmissionDTOs;
using EntityLayer.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.DTOs.CarDTOs
{
    public class CarReadActivDto
    {
        public string Name { get; set; }
        public byte Seat { get; set; }
        public short Luggage { get; set; }
        public short Engine { get; set; }
        public DateTime Year { get; set; }
        public double FuelEconomy { get; set; }
        public double Kilometer { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string PhotoPath { get; set; }
        public bool IsRented { get; set; } = false;


        public  BrandReadDto Brand { get; set; }
        public  BodyReadDto Body { get; set; }
        public  DoorReadDto Door { get; set; }
        public  FuelReadDto Fuel { get; set; }
        public  TransmissionReadDto Transmission { get; set; }
    }
}
