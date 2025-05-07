namespace Data.Entities
{
    public class ExportReceipts
    {
        public int ExportID { get; set; }
        public DateTime ExportDate { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public List<ExportDetails> ExportDetails { get; set; }
    }
}
