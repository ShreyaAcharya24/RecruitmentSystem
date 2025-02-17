using RecruitmentSystem.Enums;

namespace RecruitmentSystem.DTOs
{
    public class VerificationDTO
    {
        public int ApplicationID { get; set; }
        public string DocumentPath { get; set; }
        public VerificationStatus Status { get; set; }
        public string Remarks { get; set; }
    }
}
