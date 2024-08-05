using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LledgerApi.Data;
using LledgerApi.Models;
using LledgerApi.ViewModels;

namespace LledgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgersController : ControllerBase
    {
        private readonly LledgerApiContext _context;

        public LedgersController(LledgerApiContext context)
        {
            _context = context;
        }

        // GET: api/Ledgers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ledger>>> GetGroup()
        {
            return await _context.Group.ToListAsync();
        }

        // GET: api/Ledgers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ledger>> GetLedger(int id)
        {
            var ledger = await _context.Group.FindAsync(id);

            if (ledger == null)
            {
                return NotFound();
            }

            return ledger;
        }

        // PUT: api/Ledgers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedger(int id, LedgerVM ledgerVM)
        {
            if (!LedgerExists(id))
            {
                return BadRequest();
            }
            Ledger ledger = ledgerVM.Toledger(ledgerVM);

            _context.Entry(ledger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerExists(id))
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

        // POST: api/Ledgers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ledger>> PostLedger(LedgerVM ledgerVM)
        {
            Ledger ledger = ledgerVM.Toledger(ledgerVM);
            _context.Group.Add(ledger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLedger", new { id = ledger.Id }, ledger);
        }

        // DELETE: api/Ledgers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLedger(int id)
        {
            var ledger = await _context.Group.FindAsync(id);
            if (ledger == null)
            {
                return NotFound();
            }

            _context.Group.Remove(ledger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LedgerExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
    }
}
