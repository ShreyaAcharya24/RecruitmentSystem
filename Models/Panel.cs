using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class Panel
    {
        [Key]
        public int PanelID { get; set; }

        [Required]
        [ForeignKey("InterviewRound")]
        public int InterviewRoundID { get; set; }

        [JsonIgnore]
        public InterviewRound InterviewRound { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int InterviewerID { get; set; }

        [JsonIgnore]
        public Employee Interviewer { get; set; }
    }
}
