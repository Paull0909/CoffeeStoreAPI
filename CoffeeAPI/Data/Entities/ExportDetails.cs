namespace Data.Entities
{
    public class ExportDetails
    {
        public int  ExportDetailID { get; set; }
        public int ExportID { get; set; }
        public int MaterialID { get; set; }
        public float Quantity { get; set; }
        public ExportReceipts Export { get; set; }
        public Materials Materials { get; set; }
    }
}
