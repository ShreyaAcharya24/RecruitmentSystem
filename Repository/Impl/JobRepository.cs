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
            return await _context.Jobs
            .Include(j => j.Employee)
            .Include(j => j.JobSkills)
                .ThenInclude(js => js.Skill)
            .ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _context.Jobs
            .Include(j => j.Employee)
            .Include(j => j.JobSkills)
                .ThenInclude(js => js.Skill)
            .FirstOrDefaultAsync(j => j.JobID == id);
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

        public async Task<bool> UpdateJobStatus(int jobId, JobStatus status, string statusReason)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job == null) return false;

            job.Status = status;
            job.StatusReason = statusReason;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AddSkillsToJob(int jobId, List<int> skillIds)
        {
            var job = await GetJobById(jobId);

            if (job != null)
            {
                foreach (var skillId in skillIds)
                {
                    var skill = await _context.Skills.FindAsync(skillId);
                    if (skill != null && !job.JobSkills.Any(js => js.SkillID == skillId))
                    {
                        job.JobSkills.Add(new JobSkill { JobID = jobId, SkillID = skillId });
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
