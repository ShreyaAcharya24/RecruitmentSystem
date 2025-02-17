using System.ComponentModel.DataAnnotations;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.DTOs
{
    public class JobCreateDTO
    {
        public string Position { get; set; }
        public int NoOfPositions { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public JobStatus Status { get; set; }
        public string StatusReason { get; set; }
        public string PreferredSkills { get; set; }
        public string OtherCriteria { get; set; }
        public int RequiredExperience { get; set; }
        public int Rounds { get; set; } = 3;
        public int PostedBy { get; set; }  // EmployeeID who posted the job
        public int DriveID { get; set; }
    }
}