using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class InventoryLogs
    {
        public int InventoryLogID { get; set; }
        public int MaterialID { get; set; }
        public DateTime ChangeDate { get; set; }
        [Required]
        public string ChangeType { get; set; }
        public float QuantityChange { get; set; }
        public string Note { get; set; }
        public Materials Materials { get; set; }
    }
}
