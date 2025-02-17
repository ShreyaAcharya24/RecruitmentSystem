using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace RecruitmentSystem.Models
{
    public class Application
    {

        [Key]
        public int ApplicationID {get; set;}

        [ForeignKey("Job")]
        public int JobID {get; set;}

        [JsonIgnore]
        public Job? Job {get; set;}


        [ForeignKey("Candidate")]
        public int CandidateID {get; set;}

        [JsonIgnore]
        public Candidate? Candidate {get; set;}

        public ApplicationStatus Status {get; set;}

       [ForeignKey("Employee")]
        public int? ReviewerID {get; set;}
        
        [JsonIgnore]
        public Employee? Reviewer {get; set;}

        public string Comments {get; set;}

    }
}