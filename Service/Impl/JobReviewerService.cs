using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class JobReviwerService : IJobReviewerService
    {
        private readonly IJobReviewerRepository _jobReviewerRepository;

        public JobReviwerService(IJobReviewerRepository jobReviewerRepository)
        {
            _jobReviewerRepository = jobReviewerRepository;
        }

        public async Task<IEnumerable<JobReviwer>> GetAllJobReviews() => await _jobReviewerRepository.GetAllJobReviews();
        public async Task<JobReviwer> GetJobReviewsById(int id) => await _jobReviewerRepository.GetJobReviewsById(id);
        public async Task<IEnumerable<JobReviwer>> GetJobReviewsByJobId(int jobId) => await _jobReviewerRepository.GetJobReviewsByJobId(jobId);
        public async Task<IEnumerable<JobReviwer>> GetJobReviewsByReviewerId(int reviewerId) => await _jobReviewerRepository.GetJobReviewsByReviewerId(reviewerId);
        public async Task<JobReviwer> AddJobReviewer(JobReviwer jobReviwer) => await _jobReviewerRepository.AddJobReviewer(jobReviwer);
        public async Task<bool> DeleteJobReviewer(int id) => await _jobReviewerRepository.DeleteJobReviewer(id);
   
    }
}