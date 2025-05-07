namespace Data.Entities
{
    public class ImportReceipts
    {
        public int ImportID { get; set; }
        public int SupplierID { get; set; }
        public DateTime ImportDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Suppliers Suppliers { get; set; }
        public List<ImportDetails> ImportDetails { get; set; }
    }
}
