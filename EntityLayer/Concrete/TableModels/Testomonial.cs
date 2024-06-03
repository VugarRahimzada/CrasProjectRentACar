using CoreLayer.Entities;

namespace EntityLayer.Concrete.TableModels
{
    public class Testomonial : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string PhotoPath { get; set; }
        public string LinkedIn { get; set; }
    }
}
