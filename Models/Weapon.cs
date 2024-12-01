namespace SOACA2.Models
{
    public class Weapon
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public double dmg { get; set; }
        public string? description { get; set; }
        public int CharacterId { get; set; } // Foreign Key

        public Character Character { get; set; }
    }
}
