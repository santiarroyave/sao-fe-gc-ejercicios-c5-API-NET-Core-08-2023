using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex03.Data;
using ex03.Models;

namespace ex03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CientificoController : ControllerBase
    {
        private readonly APIContext _context;

        public CientificoController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cientificoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientifico>>> Getcientifico()
        {
          if (_context.cientifico == null)
          {
              return NotFound();
          }
            return await _context.cientifico.ToListAsync();
        }

        // GET: api/Cientificoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientifico>> GetCientifico(string id)
        {
          if (_context.cientifico == null)
          {
              return NotFound();
          }
            var cientifico = await _context.cientifico.FindAsync(id);

            if (cientifico == null)
            {
                return NotFound();
            }

            return cientifico;
        }

        // PUT: api/Cientificoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientifico(string id, Cientifico cientifico)
        {
            if (id != cientifico.dni)
            {
                return BadRequest();
            }

            _context.Entry(cientifico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CientificoExists(id))
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

        // POST: api/Cientificoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cientifico>> PostCientifico(Cientifico cientifico)
        {
          if (_context.cientifico == null)
          {
              return Problem("Entity set 'APIContext.cientifico'  is null.");
          }
            _context.cientifico.Add(cientifico);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CientificoExists(cientifico.dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCientifico", new { id = cientifico.dni }, cientifico);
        }

        // DELETE: api/Cientificoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCientifico(string id)
        {
            if (_context.cientifico == null)
            {
                return NotFound();
            }
            var cientifico = await _context.cientifico.FindAsync(id);
            if (cientifico == null)
            {
                return NotFound();
            }

            _context.cientifico.Remove(cientifico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CientificoExists(string id)
        {
            return (_context.cientifico?.Any(e => e.dni == id)).GetValueOrDefault();
        }
    }
}
