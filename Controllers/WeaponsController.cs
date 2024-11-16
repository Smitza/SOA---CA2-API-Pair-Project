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
    public class weaponsController : ControllerBase
    {
        private readonly TFContext _context;

        public weaponsController(TFContext context)
        {
            _context = context;
        }

        // GET: api/weapons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapons>>> GetWeaponSet()
        {
            return await _context.WeaponSet.ToListAsync();
        }

        // GET: api/weapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapons>> Getweapons(long id)
        {
            var weapons = await _context.WeaponSet.FindAsync(id);

            if (weapons == null)
            {
                return NotFound();
            }

            return weapons;
        }

        // PUT: api/weapons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putweapons(long id, Weapons weapons)
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
                if (!weaponsExists(id))
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

        // POST: api/weapons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weapons>> Postweapons(Weapons weapons)
        {
            _context.WeaponSet.Add(weapons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getweapons", new { id = weapons.id }, weapons);
        }

        // DELETE: api/weapons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteweapons(long id)
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

        private bool weaponsExists(long id)
        {
            return _context.WeaponSet.Any(e => e.id == id);
        }
    }
}
