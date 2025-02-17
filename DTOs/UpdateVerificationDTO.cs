using RecruitmentSystem.Enums;

namespace RecruitmentSystem.DTOs
{
    public class UpdateVerificationDTO
    {
        public VerificationStatus Status { get; set; }
        public string Remarks { get; set; }
        public int VerifierID { get; set; }
    }
}