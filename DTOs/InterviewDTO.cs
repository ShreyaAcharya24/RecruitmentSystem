using RecruitmentSystem.Enums;

namespace RecruitmentSystem.DTOs
{
    public class InterviewDTO
    {
        public int ApplicationID { get; set; }
        public int InterviewRoundID { get; set; }
        public int PanelID { get; set; }
        public DateTime DateTime { get; set; }
        public InterviewStatus Status { get; set; }
        public string InterviewFeedback { get; set; }
    }
}
