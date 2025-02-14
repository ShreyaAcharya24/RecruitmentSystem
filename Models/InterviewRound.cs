using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class InterviewRound
    {
        public int InterviewRoundID { get; set; }

        [ForeignKey("InterviewRoundMaster")]
        public int RoundID { get; set; }

        [JsonIgnore]
        public InterviewRoundMaster? Round { get; set; } 

        [ForeignKey("Job")]
        public int JobID { get; set; }

        [JsonIgnore]
        public Job? Job { get; set; } // Navigation Property

        [ForeignKey("HiringDrive")]
        public int? DriveID { get; set; } // Nullable because it's optional

        [JsonIgnore]
        public HiringDrive? HiringDrive { get; set; }


        [ForeignKey("Employee")]
        public int? InterviewerID { get; set; }

        [JsonIgnore]
        public Employee? Interviewer { get; set; }
        public int SequenceOrder { get; set; }
        public bool IsMandatory { get; set; } = true;

    }
}