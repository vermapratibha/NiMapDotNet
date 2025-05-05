using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentify.Models
{
    [Table("Vendors")]
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }


        [Required]
        public string? BusinessName { get; set; }

        [Required]
        public string? PhoneNo { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Rating { get; set; }


        public int UserId { get; set; }
    }


}
