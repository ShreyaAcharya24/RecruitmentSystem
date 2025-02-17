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
                Skills = job.JobSkills?.Select(js=>js.Skill.SkillName).ToList()
            }).ToList();
        }

        public async Task<JobResponseDTO> GetJobById(int id)
        {

            var job = await _jobRepository.GetJobById(id);
            if (job == null) return null;

            var result = new JobResponseDTO
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
                Skills = job.JobSkills?.Select(js => js.Skill.SkillName).ToList()
            };

            return result;

        }

        public async Task<bool> DeleteJob(int id) => await _jobRepository.DeleteJob(id);

        public async Task<IEnumerable<Job>> GetOpenJobs() => await _jobRepository.GetOpenJobs();

        public async Task<bool> UpdateJobStatus(int jobId, JobStatus status, string statusReason)
        {
            return await _jobRepository.UpdateJobStatus(jobId, status, statusReason);
        }

        public async Task<Job> AddJob(JobCreateDTO jobDto)
        {
            var job = new Job
            {
                Position = jobDto.Position,
                NoOfPositions = jobDto.NoOfPositions,
                Description = jobDto.Description,
                Location = jobDto.Location,
                Salary = jobDto.Salary,
                Status = jobDto.Status,
                StatusReason = jobDto.StatusReason,
                PreferredSkills = jobDto.PreferredSkills,
                OtherCriteria = jobDto.OtherCriteria,
                RequiredExperience = jobDto.RequiredExperience,
                Rounds = jobDto.Rounds,
                PostedBy = jobDto.PostedBy,
                DriveID = jobDto.DriveID
            };

            var createdJob = await _jobRepository.AddJob(job);
            if (jobDto.SkillIds != null && jobDto.SkillIds.Any())
            {
                await _jobRepository.AddSkillsToJob(createdJob.JobID, jobDto.SkillIds);
            }
            return job;
        }

        public async Task<Job> UpdateJob(int id, JobCreateDTO jobDto)
        {
            var job = await _jobRepository.GetJobById(id);
            if (job == null) return null;

            job.Position = jobDto.Position;
            job.NoOfPositions = jobDto.NoOfPositions;
            job.Description = jobDto.Description;
            job.Location = jobDto.Location;
            job.Salary = jobDto.Salary;
            job.Status = jobDto.Status;
            job.StatusReason = jobDto.StatusReason;
            job.PreferredSkills = jobDto.PreferredSkills;
            job.OtherCriteria = jobDto.OtherCriteria;
            job.RequiredExperience = jobDto.RequiredExperience;
            job.Rounds = jobDto.Rounds;
            job.PostedBy = jobDto.PostedBy;
            job.DriveID = jobDto.DriveID;

            await _jobRepository.UpdateJob(job);
            return job;
        }
    }
}
