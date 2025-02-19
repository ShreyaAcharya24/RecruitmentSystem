using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace RecruitmentSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Contact number must be between 10 to 15 digits.")]
        public string Contact { get; set; }

        [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [MaxLength(100, ErrorMessage = "Designation cannot exceed 100 characters.")]
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
