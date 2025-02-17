using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models{
public class JobReviwer {

    [Key]
    public int ReviewID {get; set;}

    [ForeignKey ("Employee")]
    public int ReviewerID {get; set;}
    
    [JsonIgnore]
    public Employee? Reviewer {get; set;}

    [ForeignKey ("Job")]
    public int JobID {get; set;}
    
    [JsonIgnore]
    public Job? Job {get; set;}


}

}
