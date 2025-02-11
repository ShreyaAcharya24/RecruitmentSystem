using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobSkillRepository _jobSkillRepository;

        public JobService(IJobRepository jobRepository, IJobSkillRepository jobSkillRepository)
        {
            _jobRepository = jobRepository;
            _jobSkillRepository = jobSkillRepository;
        }


       public async Task<IEnumerable<JobResponseDTO>> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobs();

            return jobs.Select(job => new JobResponseDTO
            {
                Position = job.Position,
                NoOfPositions = job.NoOfPositions,
                Description = job.Description,
                Location = job.Location,
                Salary = job.Salary,
                Status = job.Status,
                StatusReason = job.StatusReason,
                PreferredSkills = job.PreferredSkills,
                OtherCriteria = job.OtherCriteria,
                RequiredExperience = job.RequiredExperience,
                Rounds = job.Rounds,
                JobSkills = job.JobSkills.Select(js => new JobSkillDTO
                {
                    JobSkillID = js.JobSkillID,
                    SkillID = js.SkillID,
                    SkillName = js.Skill?.SkillName
                }).ToList()
            }).ToList();
        }

        public async Task<Job> GetJobById(int id) => await _jobRepository.GetJobById(id);

        public async Task<Job> AddJob(Job job) => await _jobRepository.AddJob(job);

        public async Task<Job> UpdateJob(Job job) => await _jobRepository.UpdateJob(job);

        public async Task<bool> DeleteJob(int id) => await _jobRepository.DeleteJob(id);

        public async Task<IEnumerable<Job>> GetOpenJobs() => await _jobRepository.GetOpenJobs();

        public async Task<bool> UpdateJobStatus(int jobId, JobStatus status, string statusReason)
        {
            return await _jobRepository.UpdateJobStatus(jobId, status, statusReason);
        }

        
    }
}
