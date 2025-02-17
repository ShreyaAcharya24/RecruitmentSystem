using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RecruitmentSystem.Enums;

namespace RecruitmentSystem.Models
{
    public class Verification
    {
        [Key]
        public int VerificationID { get; set; }

        [ForeignKey("Application")]
        public int ApplicationID { get; set; }
        
        [JsonIgnore]
        public Application Application { get; set; }

        [MaxLength(500)]
        public string? DocumentPath { get; set; } // PDF file path

        public VerificationStatus Status { get; set; } = VerificationStatus.InProgress; // Default = InProgress

        [MaxLength(255)]
        public string? Remarks { get; set; }

        [ForeignKey("Employee")]
        public int? VerifierID { get; set; } // Nullable, assigned when HR verifies
        
        [JsonIgnore]
        public Employee Verifier { get; set; }
    }
}
