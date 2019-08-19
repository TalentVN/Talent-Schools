using System.ComponentModel.DataAnnotations;

namespace TSM.Models
{
    public class UserAdminModel
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string JwtRole { get; set; }
        
        public string Address { get; set; }
    }
}
