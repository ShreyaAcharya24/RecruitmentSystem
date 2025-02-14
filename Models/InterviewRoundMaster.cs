using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class InterviewRoundMaster
    {

        [Key]
        public int RoundID { get; set; }
        public string RoundName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; } = true;
       
        [JsonIgnore]
        public ICollection<InterviewRound> InterviewRounds { get; set; }

    }
}