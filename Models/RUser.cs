using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace RecruitmentSystem.Models
{
    public class RUser
    {
        [Key]
        public int RUserID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(20)")] // Explicitly store as string in DB
        [EnumDataType(typeof(UserRole))] 
        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public UserRole Role { get; set; } // Enum: Admin, Employee, Candidate
    }
}
