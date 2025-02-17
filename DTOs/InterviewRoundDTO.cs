namespace RecruitmentSystem.DTOs
{
    public class InterviewRoundDTO
    {
        public int RoundMasterID { get; set; }
        public int JobID { get; set; }
        public int SequenceOrder { get; set; }
        public bool IsFinalRound { get; set; }
    }
}
