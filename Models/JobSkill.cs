using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class JobSkill
    {
        [Key]
        public int JobSkillID { get; set; }

        [ForeignKey("Job")]
        public int JobID { get; set; }

        [JsonIgnore]
        public Application? Job { get; set; }

        [ForeignKey("Skill")]
        public int SkillID { get; set; }
        [JsonIgnore]
        public Skill? Skill { get; set; }
    }
}
