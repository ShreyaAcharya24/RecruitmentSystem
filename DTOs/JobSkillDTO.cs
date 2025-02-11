using System.ComponentModel.DataAnnotations;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.DTOs
{
public class JobSkillDTO
    {
        public int JobSkillID { get; set; }
        public int SkillID { get; set; }
        public string SkillName { get; set; }
    }

}