using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetApi.Models;

namespace DotNetApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class aboutMeItemsController : ControllerBase
    {
        private readonly aboutMeContext _context;

        public aboutMeItemsController(aboutMeContext context)
        {
            _context = context;
        }

        // GET: api/AboutItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<aboutMeItem>>> GetTodoItems()
        {
          if (_context.aboutMeItems == null)
          {
              return NotFound();
          }
            return await _context.aboutMeItems.ToListAsync();
        }

        // GET: api/AboutItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<aboutMeItem>> GetaboutMeItem(long id)
        {
          if (_context.aboutMeItems == null)
          {
              return NotFound();
          }
            var aboutItem = await _context.aboutMeItems.FindAsync(id);

            if (aboutItem == null)
            {
                return NotFound();
            }

            return aboutItem;
        }

        // PUT: api/AboutItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutaboutMeItem(long id, aboutMeItem aboutItem)
        {
            if (id != aboutItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(aboutItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aboutMeItemExists(id))
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

        // POST: api/AboutItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<aboutMeItem>> PostaboutMeItem(aboutMeItem aboutItem)
        {
         
            _context.aboutMeItems.Add(aboutItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetaboutMeItem), new { id = aboutItem.Id }, aboutItem);
        }

        // DELETE: api/AboutItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteaboutMeItem(long id)
        {
            if (_context.aboutMeItems == null)
            {
                return NotFound();
            }
            var aboutItem = await _context.aboutMeItems.FindAsync(id);
            if (aboutItem == null)
            {
                return NotFound();
            }

            _context.aboutMeItems.Remove(aboutItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool aboutMeItemExists(long id)
        {
            return (_context.aboutMeItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    private static aboutMeItemDTO ItemToDTO(aboutMeItem AboutItem) =>
       new aboutMeItemDTO
       {
           Id = AboutItem.Id,
           Name = AboutItem.Name,
           IsComplete = AboutItem.IsComplete
       };
}

