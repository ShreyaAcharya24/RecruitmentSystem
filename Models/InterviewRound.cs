using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class InterviewRound
    {
        [Key]
        public int InterviewRoundID { get; set; }

        [Required]
        [ForeignKey("RoundMaster")]
        public int RoundMasterID { get; set; }

        [JsonIgnore]
        public RoundMaster RoundMaster { get; set; }

        [Required]
        [ForeignKey("Job")]
        public int JobID { get; set; }

        [JsonIgnore]
        public Job Job { get; set; }

        [Required]
        public int SequenceOrder { get; set; } // Order of the round

        public bool IsFinalRound { get; set; } = false;
    }
}
