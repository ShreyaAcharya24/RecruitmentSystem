using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RecruitmentSystem.Enums;

namespace RecruitmentSystem.Models
{
    public class Interview
    {
        [Key]
        public int InterviewID { get; set; }

        [Required]
        [ForeignKey("Application")]
        public int ApplicationID { get; set; }

        [JsonIgnore]
        public Application Application { get; set; }

        [Required]
        [ForeignKey("InterviewRound")]
        public int InterviewRoundID { get; set; }

        [JsonIgnore]
        public InterviewRound InterviewRound { get; set; }

        [Required]
        [ForeignKey("Panel")]
        public int PanelID { get; set; }

        [JsonIgnore]
        public Panel Panel { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public InterviewStatus Status { get; set; } // Scheduled, Completed, Cancelled

        public string InterviewFeedback { get; set; }

        public PassStatus? PassStatus { get; set; } = null; // Initially NULL
    }
}
