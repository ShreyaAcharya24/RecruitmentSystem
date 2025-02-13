using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class InterviewRoundMaster
    {

        [Key]
        public int RoundID { get; set; }
        public string RoundName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; } = true;

        // Navigation Property
        public ICollection<InterviewRound> InterviewRounds { get; set; }

    }
}