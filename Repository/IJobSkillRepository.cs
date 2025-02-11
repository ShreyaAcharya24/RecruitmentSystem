using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IJobSkillRepository
    {


        Task<IEnumerable<JobSkill>> GetAllJobSkills();
        Task<JobSkill> GetJobSkillById(int id);
        Task<IEnumerable<JobSkill>> GetJobSkillsByJobId(int jobId);
        Task<JobSkill> AddJobSkill(JobSkill jobSkill);
        Task<bool> DeleteJobSkill(int id);
        Task<IEnumerable<JobSkill>> AddJobSkills(List<JobSkill> jobSkills);
    }
}
