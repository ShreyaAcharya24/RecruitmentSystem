using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class CandidateSkillRepository : ICandidateSkillRepository
    {
        private readonly AppDbContext _context;

        public CandidateSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills()
        {
            return await _context.CandidateSkills.Include(cs => cs.Candidate).Include(cs => cs.Skill).ToListAsync();
        }

        public async Task<CandidateSkill> GetCandidateSkillById(int id)
        {
            return await _context.CandidateSkills.Include(cs => cs.Candidate).Include(cs => cs.Skill)
                .FirstOrDefaultAsync(es => es.CandidateSkillID == id);
        }

        public async Task<IEnumerable<CandidateSkill>> GetSkillsByCandidateId(int candidateId)
        {
            return await _context.CandidateSkills.Include(cs => cs.Skill)
                .Where(cs => cs.CandidateID == candidateId).ToListAsync();
        }

        public async Task<CandidateSkill> AddCandidateSkill(CandidateSkill candidateSkill)
        {

            var candidate = await _context.Candidates.FindAsync(candidateSkill.CandidateID);
            var skill = await _context.Skills.FindAsync(candidateSkill.SkillID);
            if (candidate == null)
            {

                throw new Exception("Invalid Candidate ID");
            }

            else if (skill == null)
            {

                return null;
            }

            candidateSkill.Candidate = candidate;
            candidateSkill.Skill = skill;

            _context.CandidateSkills.Add(candidateSkill);
            await _context.SaveChangesAsync();
            return candidateSkill;
        }

        public async Task<bool> DeleteCandidateSkill(int id)
        {
            var candidateSkill = await _context.CandidateSkills.FindAsync(id);
            if (candidateSkill == null) return false;

            _context.CandidateSkills.Remove(candidateSkill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
