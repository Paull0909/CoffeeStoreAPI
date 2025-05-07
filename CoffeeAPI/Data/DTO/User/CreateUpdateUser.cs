using System.ComponentModel.DataAnnotations;

namespace Data.DTO.User
{
    public class CreateUpdateUser
    {
        //To avoid NullReferenceExceptions at runtime,
        //initialise Claims and Roles with a new list in the constructor.
        public CreateUpdateUser()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
