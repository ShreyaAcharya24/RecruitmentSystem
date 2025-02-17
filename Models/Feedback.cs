using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [Required]
        [ForeignKey("Interview")]
        public int InterviewID { get; set; }

        [JsonIgnore]
        public Interview Interview { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comments { get; set; }
    }
}
