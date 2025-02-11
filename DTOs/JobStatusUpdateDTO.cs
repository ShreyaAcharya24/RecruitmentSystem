using System.ComponentModel.DataAnnotations;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.DTOs
{
    public class JobStatusUpdateDTO
    {
        [Required]
        public JobStatus Status { get; set; }
        
        [MaxLength(255)]
        public string StatusReason { get; set; }
    }
}