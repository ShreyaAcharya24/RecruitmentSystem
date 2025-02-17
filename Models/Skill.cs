using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        [Required]
        [MaxLength(100)]
        public string SkillName { get; set; }

        [ForeignKey("SkillCategory")]
        public int CategoryID { get; set; }

        [JsonIgnore]
        public SkillCategory? SkillCategory { get; set; }

        public ICollection<JobSkill> JobSkills { get; set; }
    }
}
