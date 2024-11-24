using System.ComponentModel.DataAnnotations;

namespace SOACA2.Models
{
    public class CharacterWeapon
    {
        [Key] public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int WeaponId { get; set; }
        public Weapons Weapon { get; set; }
        public int Slot { get; set; }
    }
}
