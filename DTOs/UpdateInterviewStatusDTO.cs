using RecruitmentSystem.Enums;

namespace RecruitmentSystem.DTOs
{
    public class UpdateInterviewStatusDTO
    {
        public InterviewStatus Status { get; set; }
        public PassStatus? PassStatus { get; set; } // Nullable to allow partial updates
    }
}
