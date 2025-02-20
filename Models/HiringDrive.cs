using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class HiringDrive
    {
        [Key]
        public int DriveID { get; set; }
        
        public string DriveName { get; set; }
        public int Year { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Location { get; set; }
    

    }
}