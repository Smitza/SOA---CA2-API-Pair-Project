using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQL.AspNet.Schemas;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SOACA2.Models
{
    public class TFQuery : GraphController
    {
        //Set TFContext to use the GraphQL context
        private readonly TFContext _context;
        public TFQuery(TFContext context) 
        {
            _context = context;
        }

        [QueryRoot("characters")]
        public IQueryable<Character> GetAllCharacters()
        {
            return _context.Characters.Include(c => c.Weapons); 
        }

        [QueryRoot(typeof(Character))]
        public IQueryable<Character> GetRole(string searchrole)
        {
            return _context.Characters.Where(c => c.role.Equals(searchrole, StringComparison.OrdinalIgnoreCase));
        }

        [QueryRoot("weapons")]
        public IQueryable<Weapon> GetAllWeapons()
        {
            return _context.Weapons.Include(c => c.Character);
        }
    }

}
