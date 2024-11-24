using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOACA2.Models;

namespace SOACA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterWeaponsController : ControllerBase
    {
        private readonly TFContext _context;

        public CharacterWeaponsController(TFContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        // GET: api/CharacterWeapons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterWeapon>>> GetCharacterWeapons()
        {
            return await _context.CharacterWeapons.ToListAsync();
        }

        // GET: api/CharacterWeapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterWeapon>> GetCharacterWeapon(int id)
        {
            var characterWeapon = await _context.CharacterWeapons.FindAsync(id);

            if (characterWeapon == null)
            {
                return NotFound();
            }

            return characterWeapon;
        }

        // PUT: api/CharacterWeapons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterWeapon(int id, CharacterWeapon characterWeapon)
        {
            if (id != characterWeapon.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(characterWeapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterWeaponExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CharacterWeapons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterWeapon>> PostCharacterWeapon(CharacterWeapon characterWeapon)
        {
            _context.CharacterWeapons.Add(characterWeapon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterWeaponExists(characterWeapon.CharacterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCharacterWeapon", new { id = characterWeapon.CharacterId }, characterWeapon);
        }

        // DELETE: api/CharacterWeapons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterWeapon(int id)
        {
            var characterWeapon = await _context.CharacterWeapons.FindAsync(id);
            if (characterWeapon == null)
            {
                return NotFound();
            }

            _context.CharacterWeapons.Remove(characterWeapon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterWeaponExists(int id)
        {
            return _context.CharacterWeapons.Any(e => e.CharacterId == id);
        }
    }
}
