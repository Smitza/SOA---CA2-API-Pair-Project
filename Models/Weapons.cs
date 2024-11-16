namespace SOACA2.Models
{
    public class Weapons
    {
        public long id { get; set; }
        public string? name { get; set; }
        public List<Character> classes;
        public string? type { get; set; }
        public double dmg { get; set; }
        public string? description { get; set; }
    }
}
