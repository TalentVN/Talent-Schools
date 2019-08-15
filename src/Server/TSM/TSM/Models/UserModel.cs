using System.ComponentModel.DataAnnotations;

namespace TSM.Models
{
    public class UserModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
