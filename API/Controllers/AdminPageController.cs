using API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminPageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AdminPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AdminPage
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Data>>> GetAllData()
        {
            return await _context.Datas.ToListAsync();
        }

        // GET: api/AdminPage/5
        [HttpGet("course/{id}")]
        public async Task<ActionResult<Data>> GetData(int id)
        {
            var data = await _context.Datas.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        // POST: api/AdminPage
        [HttpPost]
        public async Task<ActionResult<Data>> CreateData(Data data)
        {
            _context.Datas.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetData), new { id = data.Id }, data);
        }

        // PUT: api/AdminPage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(int id, Data data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
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

        // DELETE: api/AdminPage/5
        private bool DataExists(int id)
        {
            return _context.Datas.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var data = await _context.Datas.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Datas.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
