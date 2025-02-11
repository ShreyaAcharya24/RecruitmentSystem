using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IJobService
    {
       Task<IEnumerable<JobResponseDTO>> GetAllJobs();
        Task<Job> GetJobById(int id);
        Task<Job> AddJob(Job job);
        Task<Job> UpdateJob(Job job);
        Task<bool> DeleteJob(int id);
        Task<IEnumerable<Job>> GetOpenJobs();

        Task<bool> UpdateJobStatus(int jobId, JobStatus status, string statusReason);

    }
}
