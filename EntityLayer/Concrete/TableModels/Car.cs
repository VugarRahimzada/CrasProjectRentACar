using CoreLayer.Entities;
using System.Xml.Linq;

namespace EntityLayer.Concrete.TableModels
{
    public partial class Car : BaseEntity
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


        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int BodyId { get; set; }
        public virtual Body Body { get; set; }
        public int DoorId { get; set; }
        public virtual Door Door { get; set; }
        public int FuelId { get; set; }
        public virtual Fuel Fuel { get; set; }
        public int TransmissionId { get; set; }
        public virtual Transmission Transmission { get; set; }


    }
}
