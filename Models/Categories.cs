using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentify.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }

}
