using Entities.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstallmentsController(AppDbContext db) : ControllerBase    
    {
        private readonly AppDbContext _db = db;

        [HttpGet("student/{studentId:int}")]
        public async Task<IActionResult> GetInstallmentsByStudent(int studentId)
        {
            var installments = await _db.Installments
            .Where(p => p.StudentId == studentId)            
            .AsNoTracking()
            .ToListAsync();

            return Ok(installments);
        }
        
        [HttpPut("{id:int}/pay")]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            var installment = await _db.Installments.FindAsync(id);
            if (installment == null) return NotFound();
            if (installment.Paid) return BadRequest(new { message = "Installment is already paid." });


            installment.Paid = true;
            installment.PaidAt = DateTime.UtcNow;


            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}