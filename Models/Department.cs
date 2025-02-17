using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
    }
}
