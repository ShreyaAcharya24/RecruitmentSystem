using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobById(int id);
        
        Task<Job> AddJob(Job job);
        Task<Job> UpdateJob(Job job);
        Task<bool> DeleteJob(int id);
        Task<IEnumerable<Job>> GetOpenJobs();
    }
}
