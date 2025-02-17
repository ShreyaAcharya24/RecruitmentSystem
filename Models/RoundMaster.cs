using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class RoundMaster
    {
        [Key]
        public int RoundMasterID { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoundName { get; set; }

        public string Description { get; set; }

        public bool IsDefault { get; set; } = false;
    }
}
