using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _context.Jobs.Include(j => j.Employee).ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _context.Jobs.Include(j => j.Employee).FirstOrDefaultAsync(j => j.JobID == id);
        }

        public async Task<Job> AddJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> UpdateJob(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return false;

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<IEnumerable<Job>> GetOpenJobs()
        {
            return await _context.Jobs
                .Include(j => j.Employee)
                .Where(j => j.Status == JobStatus.Open) 
                .ToListAsync();
        }
    }
}
