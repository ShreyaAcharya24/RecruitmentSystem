using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository.Impl
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Application> SubmitApplication(Application application)
        {
            application.Status = ApplicationStatus.Submitted;
            application.ReviewerID = null;
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _context.Applications
                .Include(a => a.Job)
                .Include(a => a.Candidate)
                .ToListAsync();
        }

        public async Task<Application> GetApplicationById(int id)
        {
            return await _context.Applications
                .AsTracking()
                .Include(a => a.Job)
                .Include(a => a.Candidate)
                .FirstOrDefaultAsync(a => a.ApplicationID == id);
        }

        public async Task<IEnumerable<Application>> GetApplicationsByCandidate(int candidateId)
        {
            return await _context.Applications.Where(a => a.CandidateID == candidateId).ToListAsync();
        }

        public async Task<bool> UpdateApplicationStatus(int applicationId, ApplicationStatus status)
        {
            var application = await _context.Applications.FindAsync(applicationId);

            if (application != null)
            {
                application.Status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AssignReviewerToApplication(int applicationId, int reviewerId)
        {
            var application = await _context.Applications.FindAsync(applicationId);
            if (application == null) return false;

            application.ReviewerID = reviewerId;
            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<bool> UpdateApplication(Application application)
        {
            _context.Applications.Update(application);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
