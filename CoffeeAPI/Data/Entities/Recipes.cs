using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Recipes
    {
        public int RecipeID { get; set; }
        public int ProductSizeID { get; set; }
        public int MaterialID { get; set; }
        public float Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
        public ProductSizes ProductSizes { get; set; }
        public Materials Materials { get; set; }
    }
}
