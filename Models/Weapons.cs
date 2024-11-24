namespace SOACA2.Models
{
    public class Weapons
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public double dmg { get; set; }
        public string? description { get; set; }

        public ICollection<CharacterWeapon> CharacterWeapons { get; set; } = new List<CharacterWeapon>();
    }
}
