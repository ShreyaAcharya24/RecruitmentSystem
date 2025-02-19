using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Department Name can only contain letters and spaces.")]
        public string DepartmentName { get; set; }
    }
}
