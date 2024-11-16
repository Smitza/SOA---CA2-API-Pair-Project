namespace SOACA2.Models
{
    public class Character
    {
        public long id { get; set; }
        public required string name { get; set; }
        public required string description { get; set; }
        public string? abilities { get; set; }
        public int health { get; set; }
        public double speed { get; set; }
        public string? role { get; set; }

        public Weapons slot1 { get; set; }
        public Weapons slot2 { get; set; }
        public Weapons slot3 { get; set; }

    }
}
