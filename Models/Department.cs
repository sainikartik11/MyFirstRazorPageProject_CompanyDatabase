
using System.ComponentModel.DataAnnotations;

namespace Epicor2Database.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "size cannot exceed than 20 characters")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "size cannot exceed than 20 characters")]
        public string Location { get; set; }
    }
}
