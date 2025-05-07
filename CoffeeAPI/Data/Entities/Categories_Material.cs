using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Categories_Material
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Materials> Materials { get; set; }
    }
}
