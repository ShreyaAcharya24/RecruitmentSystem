using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class JobReviewerRepository : IJobReviewerRepository
    {
        private readonly AppDbContext _context;

        public JobReviewerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobReviwer>> GetAllJobReviews()
        {
            return await _context.JobReviwers.Include(jr => jr.Job).Include(jr => jr.Reviewer).ToListAsync();
        }

        public async Task<JobReviwer> GetJobReviewsById(int id)
        {
            return await _context.JobReviwers.Include(js => js.Job).Include(js => js.Reviewer)
                .FirstOrDefaultAsync(js => js.ReviewID == id);
        }

        public async Task<IEnumerable<JobReviwer>> GetJobReviewsByJobId(int jobId)
        {
            return await _context.JobReviwers.Include(js => js.Job)
                .Where(js => js.JobID == jobId).ToListAsync();
        }
         public async Task<IEnumerable<JobReviwer>> GetJobReviewsByReviewerId(int reviewerId)
        {
            return await _context.JobReviwers.Include(js => js.Reviewer)
                .Where(js => js.ReviewerID == reviewerId).ToListAsync();
        }

        public async Task<JobReviwer> AddJobReviewer(JobReviwer jobReviwer)
        {
            _context.JobReviwers.Add(jobReviwer);
            await _context.SaveChangesAsync();
            return jobReviwer;
        }

        public async Task<bool> DeleteJobReviewer(int id)
        {
            var jobReviewer = await _context.JobReviwers.FindAsync(id);
            if (jobReviewer == null) return false;

            _context.JobReviwers.Remove(jobReviewer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
