using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rentify.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string? RoleName { get; set; }


    }
}