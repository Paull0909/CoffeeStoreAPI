using Data.Enum;

namespace Data.Entities
{
    public class Payments
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public TransactionStatus PaymentMethod { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string content { get; set; }
        public Orders Orders { get; set; }
    }
}
