using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DI_Demo.Models.EF;

namespace DI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly bankingDBAPIContext _context;

        public TransactionController(bankingDBAPIContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionInfo>>> GetTransactionInfos()
        {
          if (_context.TransactionInfos == null)
          {
              return NotFound();
          }
            return await _context.TransactionInfos.ToListAsync();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionInfo>> GetTransactionInfo(int id)
        {
          if (_context.TransactionInfos == null)
          {
              return NotFound();
          }
            var transactionInfo = await _context.TransactionInfos.FindAsync(id);

            if (transactionInfo == null)
            {
                return NotFound();
            }

            return transactionInfo;
        }

        // PUT: api/Transaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionInfo(int id, TransactionInfo transactionInfo)
        {
            if (id != transactionInfo.TrId)
            {
                return BadRequest();
            }

            _context.Entry(transactionInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionInfoExists(id))
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

        // POST: api/Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionInfo>> PostTransactionInfo(TransactionInfo transactionInfo)
        {
          if (_context.TransactionInfos == null)
          {
              return Problem("Entity set 'bankingDBAPIContext.TransactionInfos'  is null.");
          }
            _context.TransactionInfos.Add(transactionInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionInfo", new { id = transactionInfo.TrId }, transactionInfo);
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionInfo(int id)
        {
            if (_context.TransactionInfos == null)
            {
                return NotFound();
            }
            var transactionInfo = await _context.TransactionInfos.FindAsync(id);
            if (transactionInfo == null)
            {
                return NotFound();
            }

            _context.TransactionInfos.Remove(transactionInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionInfoExists(int id)
        {
            return (_context.TransactionInfos?.Any(e => e.TrId == id)).GetValueOrDefault();
        }
    }
}
