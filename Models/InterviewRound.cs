using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentSystem.Models
{
    public class InterviewRound
    {
        public int InterviewRoundID { get; set; }
        
        [ForeignKey("InterviewRoundMaster")]
        public int RoundID { get; set; }
        public InterviewRoundMaster Round { get; set; } // Navigation Property

        [ForeignKey("Job")]
        public int JobID { get; set; }
        public Job Job { get; set; } // Navigation Property

        [ForeignKey("HiringDrive")]
        public int? DriveID { get; set; } // Nullable because it's optional
        public HiringDrive HiringDrive { get; set; }

        public int SequenceOrder { get; set; }
        public bool IsMandatory { get; set; } = true;

    }
}