using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {

        return await _context.Candidates
        .Include(c => c.RUser)
        .ToListAsync();
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _context.Candidates.Include(c => c.RUser).FirstOrDefaultAsync(c => c.CandidateID == id);
        }

        public async Task<Candidate> AddCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null) return false;

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<bool> CandidateExistsAsync(int id)
        {
            return await _context.Candidates.AnyAsync(c => c.CandidateID == id);
        }
    }
}
