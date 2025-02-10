using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class CandidateSkillService : ICandidateSkillService
    {
        private readonly ICandidateSkillRepository _candidateSkillRepository;

        public CandidateSkillService(ICandidateSkillRepository candidateSkillRepository)
        {
            _candidateSkillRepository = candidateSkillRepository;
        }

        public async Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills() => await _candidateSkillRepository.GetAllCandidateSkills();


        public async Task<IEnumerable<CandidateSkill>> GetSkillsByCandidateId(int candidateId) => await _candidateSkillRepository.GetSkillsByCandidateId(candidateId);

        public async Task<CandidateSkill> AddCandidateSkill(CandidateSkill candidateSkill) => await _candidateSkillRepository.AddCandidateSkill(candidateSkill);

        public async Task<bool> DeleteCandidateSkill(int id) => await _candidateSkillRepository.DeleteCandidateSkill(id);

        public async Task<CandidateSkill> GetCandidateSkillById(int id) => await _candidateSkillRepository.GetCandidateSkillById(id);
        
    }
}
