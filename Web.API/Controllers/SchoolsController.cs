using Entities.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolsController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _db.Schools.AsNoTracking().ToListAsync();
            return Ok(list);
        }


        [HttpGet("{id}/invoices")]
        public async Task<IActionResult> GetInvoices(int id)
        {
            var invoices = await _db.Invoices
            .Where(i => i.SchoolId == id)
            .Include(i => i.Installments)
            .ThenInclude(inst => inst.Student)
            .AsNoTracking()
            .ToListAsync();

            if (invoices == null || invoices.Count == 0) return NotFound(new { message = "Nenhuma mensalidade encontrada para esta escola." });

            return Ok(invoices);
        }
    }
}
