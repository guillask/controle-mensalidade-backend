using Entities.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;


        [HttpGet("{studentId}/installments")]
        public async Task<IActionResult> GetInstallments(int studentId)
        {
            var items = await _db.Installments
            .Where(i => i.StudentId == studentId)            
            .AsNoTracking()
            .ToListAsync();


            if (items == null || items.Count == 0) return NotFound(new { message = "Nenhuma parcela encontrada para este aluno." });


            var total = items.Sum(i => i.Amount);
            var paid = items.Where(i => i.Paid).Sum(i => i.Amount);
            var pending = total - paid;


            return Ok(new { total, paid, pending, installments = items });
        }
    }
}
