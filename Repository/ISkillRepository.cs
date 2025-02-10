using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int id);
        Task<Skill> AddSkill(Skill skill);
        Task<Skill> UpdateSkill(Skill skill);
        Task<bool> DeleteSkill(int id);
         Task<bool> SkillExistsAsync(int id);
    }
}
