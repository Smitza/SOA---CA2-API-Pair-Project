namespace SOACA2.Models
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> WeaponNames { get; set; }
    }

}
