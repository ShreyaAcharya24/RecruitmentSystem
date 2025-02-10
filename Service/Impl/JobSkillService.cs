using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class JobSkillService : IJobSkillService
    {
        private readonly IJobSkillRepository _jobSkillRepository;

        public JobSkillService(IJobSkillRepository jobSkillRepository)
        {
            _jobSkillRepository = jobSkillRepository;
        }

        public async Task<IEnumerable<JobSkill>> GetAllJobSkills() => await _jobSkillRepository.GetAllJobSkills();

        public async Task<JobSkill> GetJobSkillById(int id) => await _jobSkillRepository.GetJobSkillById(id);

        public async Task<IEnumerable<JobSkill>> GetJobSkillsByJobId(int jobId) => await _jobSkillRepository.GetJobSkillsByJobId(jobId);

        public async Task<JobSkill> AddJobSkill(JobSkill jobSkill) => await _jobSkillRepository.AddJobSkill(jobSkill);

        public async Task<bool> DeleteJobSkill(int id) => await _jobSkillRepository.DeleteJobSkill(id);
    }
}
