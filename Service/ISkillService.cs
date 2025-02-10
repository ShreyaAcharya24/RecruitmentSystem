using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int id);
        Task<Skill> AddSkill(Skill skill);
        Task<Skill> UpdateSkill(Skill skill);
        Task<bool> DeleteSkill(int id);

         Task<bool> DoesSkillExistAsync(int id);
    }
}
