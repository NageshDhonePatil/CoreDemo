using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [Range(21, 100)]
        public int Age { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [Required]
        public double Salary { get; set; }
    }
}
