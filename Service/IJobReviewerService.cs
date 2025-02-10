using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IJobReviewerService
    {
        Task<IEnumerable<JobReviwer>> GetAllJobReviews();
        Task<JobReviwer> GetJobReviewsById(int id);
        Task<IEnumerable<JobReviwer>> GetJobReviewsByJobId(int jobId);
        Task<IEnumerable<JobReviwer>> GetJobReviewsByReviewerId(int reviewerId);
        Task<JobReviwer> AddJobReviewer(JobReviwer jobReviwer);
        Task<bool> DeleteJobReviewer(int id);
    }
}
