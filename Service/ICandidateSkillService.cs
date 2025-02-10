using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface ICandidateSkillService
    {
        Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills();
        Task<CandidateSkill> GetCandidateSkillById(int id);
        Task<IEnumerable<CandidateSkill>> GetSkillsByCandidateId(int candidateId);
        Task<CandidateSkill> AddCandidateSkill(CandidateSkill candidateSkill);
        Task<bool> DeleteCandidateSkill(int id);
    }
}
