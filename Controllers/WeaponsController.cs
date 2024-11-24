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
    public class WeaponsController : ControllerBase
    {
        private readonly TFContext _context;

        public WeaponsController(TFContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        // GET: api/Weapons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapons>>> GetWeaponSet()
        {
            return await _context.WeaponSet.ToListAsync();
        }

        // GET: api/Weapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapons>> GetWeapons(int id)
        {
            var weapons = await _context.WeaponSet.FindAsync(id);

            if (weapons == null)
            {
                return NotFound();
            }

            return weapons;
        }

        // PUT: api/Weapons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapons(int id, Weapons weapons)
        {
            if (id != weapons.id)
            {
                return BadRequest();
            }

            _context.Entry(weapons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponsExists(id))
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

        // POST: api/Weapons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weapons>> PostWeapons(Weapons weapons)
        {
            _context.WeaponSet.Add(weapons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapons", new { id = weapons.id }, weapons);
        }

        // DELETE: api/Weapons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapons(int id)
        {
            var weapons = await _context.WeaponSet.FindAsync(id);
            if (weapons == null)
            {
                return NotFound();
            }

            _context.WeaponSet.Remove(weapons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponsExists(int id)
        {
            return _context.WeaponSet.Any(e => e.id == id);
        }
    }
}
