using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace RecruitmentSystem.Models
{
    public enum ApplicationStatus {
        Submitted,
        Shortlisted,
        Interviewed,
        UnderReview,
        Hired,
        Rejected,

    }

    public class Application
    {

        [Key]
        public int ApplicationID {get; set;}

        [ForeignKey("Job")]
        public int JobID {get; set;}

        [JsonIgnore]
        public Application? Job {get; set;}


        [ForeignKey("Candidate")]
        public int CandidateID {get; set;}

        [JsonIgnore]
        public Candidate? Candidate {get; set;}

        public ApplicationStatus Status {get; set;}


// Only Reviewers from JobReviewer Table can be here
        [ForeignKey("Employee")]
        public int ReviewerID {get; set;}
        
        [JsonIgnore]
        public Employee? Reviewer {get; set;}

        public string Comments {get; set;}

    }
}