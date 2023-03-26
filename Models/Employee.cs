using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epicor2Database.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15,ErrorMessage ="size cannot exceed than 15 characters")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "size cannot exceed than 20 characters")]
        public string Designation { get; set; }
        public int? ManagerId{ get; set; }
        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}
