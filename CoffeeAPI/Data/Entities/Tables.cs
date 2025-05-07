using Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Tables
    {
        public int TableID { get; set; }
        [Required]
        public string TableName { get; set; }
        public TableStatus Status { get; set; }

    }
}
