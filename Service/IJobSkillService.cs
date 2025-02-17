using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IJobSkillService
    {
        Task<IEnumerable<JobSkill>> GetAllJobSkills();
        Task<JobSkill> GetJobSkillById(int id);
        Task<IEnumerable<JobSkill>> GetJobSkillsByJobId(int jobId);
        Task<JobSkill> AddJobSkill(JobSkill jobSkill);
        Task<bool> DeleteJobSkill(int id);
    }
}
