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
    public class accountsController : ControllerBase
    {
        private readonly bankingDBAPIContext _context;

        public accountsController(bankingDBAPIContext context)
        {
            _context = context;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountsInfo>>> GetAccountsInfos()
        {
          if (_context.AccountsInfos == null)
          {
              return NotFound();
          }
            return await _context.AccountsInfos.ToListAsync();
        }

        // GET: api/accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountsInfo>> GetAccountsInfo(int id)
        {
          if (_context.AccountsInfos == null)
          {
              return NotFound();
          }
            var accountsInfo = await _context.AccountsInfos.FindAsync(id);

            if (accountsInfo == null)
            {
                return NotFound();
            }

            return accountsInfo;
        }

        // PUT: api/accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountsInfo(int id, AccountsInfo accountsInfo)
        {
            if (id != accountsInfo.AccNo)
            {
                return BadRequest();
            }

            _context.Entry(accountsInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsInfoExists(id))
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

        // POST: api/accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountsInfo>> PostAccountsInfo(AccountsInfo accountsInfo)
        {
          if (_context.AccountsInfos == null)
          {
              return Problem("Entity set 'bankingDBAPIContext.AccountsInfos'  is null.");
          }
            _context.AccountsInfos.Add(accountsInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountsInfoExists(accountsInfo.AccNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountsInfo", new { id = accountsInfo.AccNo }, accountsInfo);
        }

        // DELETE: api/accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountsInfo(int id)
        {
            if (_context.AccountsInfos == null)
            {
                return NotFound();
            }
            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            _context.AccountsInfos.Remove(accountsInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountsInfoExists(int id)
        {
            return (_context.AccountsInfos?.Any(e => e.AccNo == id)).GetValueOrDefault();
        }
    }
}
