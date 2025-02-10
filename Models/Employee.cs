using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace RecruitmentSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        public string Contact { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string Designation { get; set; }

        [Required]
        public bool isActive { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }

        [ForeignKey("RUser")]
        public int RUserID { get; set; }
        
      
        public RUser RUser { get; set; }
    }
}
