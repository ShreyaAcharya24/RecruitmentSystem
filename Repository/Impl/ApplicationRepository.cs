using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _context.Applications.Include(a => a.Candidate).Include(a => a.Job).ToListAsync();
        }

        public async Task<Application> GetApplicationById(int id)
        {
            return await _context.Applications.Include(a => a.Candidate).FirstOrDefaultAsync(a => a.ApplicationID == id);
        }

        public async Task<Application> AddApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<Application> UpdateApplication(Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<bool> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null) return false;

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<IEnumerable<Application>> GetApplicationsByStatus(string status)
        {
            ApplicationStatus appStatus = (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus),status);

            if(appStatus == ApplicationStatus.Shortlisted){

                return await _context.Applications
                .Include(a => a.Candidate)
                .Where(a => a.Status == ApplicationStatus.Shortlisted) 
                .ToListAsync();

            }

            return await _context.Applications
                .Include(a => a.Candidate)
                .ToListAsync();

            
        }
    }
}
