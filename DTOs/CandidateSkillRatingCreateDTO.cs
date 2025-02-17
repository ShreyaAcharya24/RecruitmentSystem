using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.DTOs
{
    public class CandidateSkillRatingCreateDTO
    {
        [Required]
        public int ApplicationID { get; set; }

        [Required]
        public int JobSkillID { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}