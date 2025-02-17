using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{

    public class Job
    {
        [Key]
        public int JobID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [Required]
        public int NoOfPositions { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public JobStatus Status { get; set; }

        [MaxLength(255)]
        public string StatusReason { get; set; }

        public string PreferredSkills { get; set; }

        public string OtherCriteria { get; set; }

        public int RequiredExperience { get; set; }

        public int Rounds { get; set; } = 3;

        [ForeignKey("Employee")]
        public int PostedBy { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }

        [ForeignKey("HiringDrive")]
        public int DriveID { get; set; }
        
        [JsonIgnore]
        public HiringDrive HiringDrive { get; set; }

        public ICollection<JobSkill> JobSkills { get; set; }
    }
}
