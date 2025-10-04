using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Installment
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidAt { get; set; }        
    }
}
