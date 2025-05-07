namespace Data.Entities
{
    public class ImportDetails
    {
        public int ImportDetailID { get; set; }
        public int ImportID { get; set; }
        public int MaterialID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public ImportReceipts ImportReceipts { get; set; }
        public Materials Materials { get; set; }
    }
}
