using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class JobSkillRepository : IJobSkillRepository
    {
        private readonly AppDbContext _context;

        public JobSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobSkill>> AddJobSkills(List<JobSkill> jobSkills)
        {
            _context.JobSkills.AddRange(jobSkills);
            await _context.SaveChangesAsync();
            return jobSkills;
        }


        public async Task<IEnumerable<JobSkill>> GetAllJobSkills()
        {
            return await _context.JobSkills.Include(js => js.Job).Include(js => js.Skill).ToListAsync();
        }

        public async Task<JobSkill> GetJobSkillById(int id)
        {
            return await _context.JobSkills.Include(js => js.Job).Include(js => js.Skill)
                .FirstOrDefaultAsync(js => js.JobSkillID == id);
        }

        public async Task<IEnumerable<JobSkill>> GetJobSkillsByJobId(int jobId)
        {
            return await _context.JobSkills.Include(js => js.Skill)
                .Where(js => js.JobID == jobId).ToListAsync();
        }

        public async Task<JobSkill> AddJobSkill(JobSkill jobSkill)
        {
            _context.JobSkills.Add(jobSkill);
            await _context.SaveChangesAsync();
            return jobSkill;
        }

        public async Task<bool> DeleteJobSkill(int id)
        {
            var jobSkill = await _context.JobSkills.FindAsync(id);
            if (jobSkill == null) return false;

            _context.JobSkills.Remove(jobSkill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
