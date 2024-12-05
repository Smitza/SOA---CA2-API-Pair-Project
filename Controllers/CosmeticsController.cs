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
    public class CosmeticsController : ControllerBase
    {
        private readonly TFContext _context;

        public CosmeticsController(TFContext context) {
            _context = context;
    }
    // GET: api/Cosmetics
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cosmetic>>> GetCosmetics()
    {
        return await _context.Cosmetics.ToListAsync();
    }

        // GET: api/Cosmetics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cosmetic>> GetWeapon(int id)
        {
            var cosmetic = await _context.Cosmetics.FindAsync(id);

            if (cosmetic == null)
            {
                return NotFound();
            }

            return cosmetic;
        }

        // PUT: api/Cosmetics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon(int id, Cosmetic cosmetic)
        {
            if (id != cosmetic.id)
            {
                return BadRequest();
            }

            _context.Entry(cosmetic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(id))
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

        // POST: api/Cosmetics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cosmetic>> PostWeapon(Cosmetic cosmetic)
        {
            _context.Cosmetics.Add(cosmetic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapon", new { id = cosmetic.id }, cosmetic);
        }

        // DELETE: api/Cosmetics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon(int id)
        {
            var cosmetic = await _context.Cosmetics.FindAsync(id);
            if (cosmetic == null)
            {
                return NotFound();
            }

            _context.Cosmetics.Remove(cosmetic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponExists(int id)
        {
            return _context.Cosmetics.Any(e => e.id == id);
        }
    }

}


