using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentify.Models
{
    [Table("Products")]
    public class Products
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Pricepermonth { get; set; }

        [Required]
        public int Stockquantity { get; set; }

        [Required]
        public string? Imageurl { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [NotMapped]
        public string ? CategoryName { get; set; }
    }

}
