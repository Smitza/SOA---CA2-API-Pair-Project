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

        public long slot1Id { get; set; }
        public long slot2Id { get; set; }
        public long slot3Id { get; set; }


        public Weapons? slot1 { get; set; }
        public Weapons? slot2 { get; set; }
        public Weapons? slot3 { get; set; }



    }
}
