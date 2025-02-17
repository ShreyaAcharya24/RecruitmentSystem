using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class JobSkill
    {
        [Key]
        public int JobSkillID { get; set; }

        [Required]
        public int JobID { get; set; } // Foreign Key

        [ForeignKey(nameof(JobID))]
        [JsonIgnore]
        public Job Job { get; set; }

        [Required]
        public int SkillID { get; set; } // Foreign Key

        [ForeignKey(nameof(SkillID))]
        [JsonIgnore]
        public Skill Skill { get; set; }
    }
}
