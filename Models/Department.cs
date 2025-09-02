using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAssesment.Models
{
    public class Department
    {

        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Location { get; set; }

        [ForeignKey("Employee")]
        public int ManagerId { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
