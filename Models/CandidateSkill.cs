using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class CandidateSkill
    {
        [Key]
        public int CandidateSkillID { get; set; }

        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }

        [JsonIgnore]
        public Candidate? Candidate { get; set; }

        [ForeignKey("Skill")]
        public int SkillID { get; set; }
        [JsonIgnore]
        public Skill? Skill { get; set; }
    }
}
