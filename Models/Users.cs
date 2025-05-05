using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentify.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Confirm Password")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password can't be match !")]
        public string? ConfirmPassword { get; set; }

        public int RoleId { get; set; }


        [NotMapped]
        [Display(Name = "Role")]
        public string? Rolename { get; set; }


    }
}

