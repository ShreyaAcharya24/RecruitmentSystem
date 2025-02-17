using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IJobService
    {
        
        Task<Job> AddJob(JobCreateDTO jobDto);
        Task<IEnumerable<JobResponseDTO>> GetAllJobs();
        Task<JobResponseDTO> GetJobById(int id);
        Task<Job> UpdateJob(int id, JobCreateDTO jobDto);
        Task<bool> DeleteJob(int id);
        Task<IEnumerable<Job>> GetOpenJobs();

        Task<bool> UpdateJobStatus(int jobId, JobStatus status, string statusReason);

    }
}
