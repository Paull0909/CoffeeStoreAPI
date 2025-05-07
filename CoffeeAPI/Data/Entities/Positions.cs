using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Positions
    {
        public int PositionID { get; set; }
        [Required]
        public string PositionName { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public List<Employees> Employees { get; set; }
    } 
}
