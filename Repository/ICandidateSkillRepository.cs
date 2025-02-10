using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface ICandidateSkillRepository
    {
        Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills();
        Task<CandidateSkill> GetCandidateSkillById(int id);
        Task<IEnumerable<CandidateSkill>> GetSkillsByCandidateId(int candidateId);
        Task<CandidateSkill> AddCandidateSkill(CandidateSkill candidateSkillSkill);
        Task<bool> DeleteCandidateSkill(int id);
    }
}
