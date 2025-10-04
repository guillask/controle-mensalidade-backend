namespace Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int SchoolId { get; set; }
        public ICollection<Installment>? Installments { get; set; }
    }
}
