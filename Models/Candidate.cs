using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentSystem.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(15)]
        public string Contact { get; set; }

        [MaxLength(255)]
        public string AddressLine1 { get; set; }

        [MaxLength(255)]
        public string AddressLine2 { get; set; }

        [MaxLength(100)]
        public string HighestQualification { get; set; }

        [MaxLength(255)]
        public string SchoolOrUniversity { get; set; }

        public double ScoreGPA { get; set; }

        [ForeignKey("RUser")]
        public int RUserID { get; set; }
       
        public RUser RUser { get; set; }

        [MaxLength(500)]
        public string Resume { get; set; }

        public int TotalExperience { get; set; }
    }
}
