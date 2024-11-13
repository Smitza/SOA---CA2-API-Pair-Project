namespace SOACA2
{
    public class weapons
    {
        public long id { get; set; }
        public string name { get; set; }
        public List<Character> classes;
        public string? type { get; set; }
        public int dmg { get; set; }
        public int description { get; set; }
    }
}
