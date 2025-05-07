using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Role:IdentityRole<Guid>
    {
        [Required]
        public string Description { get; set; }
    }
}
