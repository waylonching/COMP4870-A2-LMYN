using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using AspNet.Security.OAuth.Validation;

namespace LmycWeb.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Borrows")]
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [EnableCors("CorsPolicy")]
    public class BorrowsApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Borrows
        [HttpGet]
        public IEnumerable<Borrow> GetBorrows()
        {
            return _context.Borrows;
        }

        // GET: api/Borrows/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBorrow([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrow = await _context.Borrows.SingleOrDefaultAsync(m => m.BorrowId == id);

            if (borrow == null)
            {
                return NotFound();
            }

            return Ok(borrow);
        }

        // PUT: api/Borrows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrow([FromRoute] int id, [FromBody] Borrow borrow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != borrow.BorrowId)
            {
                return BadRequest();
            }

            _context.Entry(borrow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowExists(id))
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

        // POST: api/Borrows
        [HttpPost]
        public async Task<IActionResult> PostBorrow([FromBody] Borrow borrow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrow", new { id = borrow.BorrowId }, borrow);
        }

        // DELETE: api/Borrows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrow([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var borrow = await _context.Borrows.SingleOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();

            return Ok(borrow);
        }

        private bool BorrowExists(int id)
        {
            return _context.Borrows.Any(e => e.BorrowId == id);
        }
    }
}