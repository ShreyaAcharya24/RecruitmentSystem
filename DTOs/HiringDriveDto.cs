namespace RecruitmentSystem.DTOs
{
    public class HiringDriveDto
    {
        public string DriveName { get; set; }
        public int Year { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Location { get; set; }
    }
}