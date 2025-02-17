using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentSystem.Models
{
    public class CandidateSkillRating
    {
        [Key]
        public int RateID { get; set; }

        [Required]
        [ForeignKey("Application")]
        public int ApplicationID { get; set; }

        [Required]
        [ForeignKey("JobSkill")]
        public int JobSkillID { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        public Application Application { get; set; }
        public JobSkill JobSkill { get; set; }
    }
}