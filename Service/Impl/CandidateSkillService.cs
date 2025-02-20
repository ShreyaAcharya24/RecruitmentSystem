using System.Reflection.Metadata.Ecma335;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class CandidateSkillService : ICandidateSkillService
    {
        private readonly ICandidateSkillRepository _candidateSkillRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISkillRepository _skillRepository;

        public CandidateSkillService(ICandidateSkillRepository candidateSkillRepository, ICandidateRepository candidateRepository, ISkillRepository skillRepository)
        {
            _candidateSkillRepository = candidateSkillRepository;
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills() => await _candidateSkillRepository.GetAllCandidateSkills();

        public async Task<IEnumerable<CandidateSkill>> GetSkillsByCandidateId(int candidateId)
        {
            var candidate = _candidateRepository.GetCandidateById(candidateId);
            if (candidate == null)
                throw new KeyNotFoundException($"Candidate with {candidateId} Doesn't exist");

            return await _candidateSkillRepository.GetSkillsByCandidateId(candidateId);
        }

        public async Task<CandidateSkill> AddCandidateSkill(CandidateSkill candidateSkill)
        {

            var candidate = await _candidateRepository.GetCandidateById(candidateSkill.CandidateID);
            if (candidate == null)
                throw new KeyNotFoundException("Cadidate does not exist.");

            candidateSkill.Candidate = candidate;

            var skillExists = await _skillRepository.GetSkillById(candidateSkill.SkillID);
            if (skillExists == null)
                throw new KeyNotFoundException("Skill does not exist.");

            candidateSkill.Skill = skillExists;

            var existingSkills = await _candidateSkillRepository.GetSkillsByCandidateId(candidateSkill.CandidateID);
            foreach (var cs in existingSkills)
            {
                if (cs.SkillID == candidateSkill.SkillID)
                {
                    throw new InvalidOperationException("This skill has been already added for this Candidate.");
                }
            }
            return await _candidateSkillRepository.AddCandidateSkill(candidateSkill);

        }
        public async Task<bool> DeleteCandidateSkill(int id)
        {
            var candidateSkill = await _candidateSkillRepository.GetCandidateSkillById(id);
            if (candidateSkill== null)
            {
                throw new KeyNotFoundException($"Candidate Skill with id {id} doesn't exist");

            }
            return await _candidateSkillRepository.DeleteCandidateSkill(id);

        }
        public async Task<CandidateSkill> GetCandidateSkillById(int id)
        {
            var candidateSkill = await _candidateSkillRepository.GetCandidateSkillById(id);
            if (candidateSkill == null)
                throw new KeyNotFoundException($"Candidate Skill with {id} doesn't exist");
            return candidateSkill;
        }



    }
}
