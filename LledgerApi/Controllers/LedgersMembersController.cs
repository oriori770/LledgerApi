using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LledgerApi.Data;
using LledgerApi.Models;

namespace LledgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgersMembersController : ControllerBase
    {
        private readonly LledgerApiContext _context;

        public LedgersMembersController(LledgerApiContext context)
        {
            _context = context;
        }

        // GET: api/LedgersMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedgersMember>>> GetLedgersMember()
        {
            return await _context.LedgersMember.ToListAsync();
        }

        // GET: api/LedgersMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LedgersMember>> GetLedgersMember(int id)
        {
            var ledgersMember = await _context.LedgersMember.FindAsync(id);

            if (ledgersMember == null)
            {
                return NotFound();
            }

            return ledgersMember;
        }

        // PUT: api/LedgersMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedgersMember(int id, LedgersMember ledgersMember)
        {
            if (id != ledgersMember.ID)
            {
                return BadRequest();
            }

            _context.Entry(ledgersMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgersMemberExists(id))
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

        // POST: api/LedgersMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LedgersMember>> PostLedgersMember(LedgersMember ledgersMember)
        {
            _context.LedgersMember.Add(ledgersMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLedgersMember", new { id = ledgersMember.ID }, ledgersMember);
        }

        // DELETE: api/LedgersMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLedgersMember(int id)
        {
            var ledgersMember = await _context.LedgersMember.FindAsync(id);
            if (ledgersMember == null)
            {
                return NotFound();
            }

            _context.LedgersMember.Remove(ledgersMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LedgersMemberExists(int id)
        {
            return _context.LedgersMember.Any(e => e.ID == id);
        }
    }
}
