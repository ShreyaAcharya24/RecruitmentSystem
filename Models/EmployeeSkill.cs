using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecruitmentSystem.Models
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }

        [ForeignKey("Skill")]
        public int SkillID { get; set; }
        [JsonIgnore]
        public Skill? Skill { get; set; }
    }
}
