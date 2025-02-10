using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetAllJobs() => await _jobRepository.GetAllJobs();

        public async Task<Job> GetJobById(int id) => await _jobRepository.GetJobById(id);

        public async Task<Job> AddJob(Job job) => await _jobRepository.AddJob(job);

        public async Task<Application> UpdateJob(Job job) => await _jobRepository.UpdateJob(job);

        public async Task<bool> DeleteJob(int id) => await _jobRepository.DeleteJob(id);

        public async Task<IEnumerable<Job>> GetOpenJobs() => await _jobRepository.GetOpenJobs();

    }
}
