using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]        
        public string Name { get; set; }=string.Empty;

        public List<Employee> Employees { get; set; }
    }
}
