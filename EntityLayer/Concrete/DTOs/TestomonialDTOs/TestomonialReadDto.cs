namespace EntityLayer.Concrete.DTOs.TestomonialDTOs
{
    public class TestomonialReadDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string PhotoPath { get; set; }
        public string LinkedIn { get; set; }
        public int Delete { get; set; } = 0;
    }
}
