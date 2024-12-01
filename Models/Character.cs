namespace SOACA2.Models
{
    public class Character
    {
        public int id { get; set; }
        public required string name { get; set; }
        public required string description { get; set; }
        public string? abilities { get; set; }
        public int health { get; set; }
        public double speed { get; set; }
        public string? role { get; set; }

        public ICollection<Weapon> Weapons  { get; set; }
    }
}
