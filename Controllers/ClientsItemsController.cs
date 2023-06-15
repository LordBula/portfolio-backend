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
    public class ClientsItemsController : ControllerBase
    {
        private readonly ClientsContext _context;

        public ClientsItemsController(ClientsContext context)
        {
            _context = context;
        }

    // GET: api/ClientsItems
    [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientsItem>>> GetTodoItems()
        {
          if (_context.ClientsItems == null)
          {
              return NotFound();
          }
            return await _context.ClientsItems.ToListAsync();
        }

    // GET: api/ClientsItems/5
    [HttpGet("{id}")]
        public async Task<ActionResult<ClientsItem>> GetClientsItem(long id)
        {
          if (_context.ClientsItems == null)
          {
              return NotFound();
          }
            var ClientsItem = await _context.ClientsItems.FindAsync(id);

            if (ClientsItem == null)
            {
                return NotFound();
            }

            return ClientsItem;
        }

    // PUT: api/ClientsItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutClientsItem(long id, ClientsItem ClientsItem)
        {
            if (id != ClientsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(ClientsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsItemExists(id))
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

    // POST: api/ClientsItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
        public async Task<ActionResult<ClientsItem>> PostClientsItem(ClientsItem ClientsItem)
        {
         
            _context.ClientsItems.Add(ClientsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientsItem), new { id = ClientsItem.Id }, ClientsItem);
        }

    // DELETE: api/ClientsItems/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientsItem(long id)
        {
            if (_context.ClientsItems == null)
            {
                return NotFound();
            }
            var ClientsItem = await _context.ClientsItems.FindAsync(id);
            if (ClientsItem == null)
            {
                return NotFound();
            }

            _context.ClientsItems.Remove(ClientsItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientsItemExists(long id)
        {
            return (_context.ClientsItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    private static ClientsItemDTO ItemToDTO(ClientsItem ClientsItem) =>
     new ClientsItemDTO
     {
         Id = ClientsItem.Id,
         Name = ClientsItem.Name,
         IsComplete = ClientsItem.IsComplete
     };
}

