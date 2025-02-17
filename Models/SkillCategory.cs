using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class SkillCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
