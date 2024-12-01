using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQL.AspNet.Schemas;

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
            return _context.Characters; 
        }

        [QueryRoot("weapons")]
        public IQueryable<Weapon> GetAllWeapons()
        {
            return _context.Weapons;
        }
    }

}
