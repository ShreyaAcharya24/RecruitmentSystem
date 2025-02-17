using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Repository.Impl
{
    public class CandidateSkillRatingRepository : ICandidateSkillRatingRepository
    {
        private readonly AppDbContext _context;

        public CandidateSkillRatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateSkillRating>> GetAllRatings()
        {
            return await _context.CandidateSkillRatings
                .Include(csr => csr.Application)
                .Include(csr => csr.JobSkill)
                .ToListAsync();
        }

        public async Task<CandidateSkillRating> GetRatingById(int id)
        {
            return await _context.CandidateSkillRatings
                .Include(csr => csr.Application)
                .Include(csr => csr.JobSkill)
                .FirstOrDefaultAsync(csr => csr.RateID == id);
        }

        public async Task<CandidateSkillRating> AddRating(CandidateSkillRating rating)
        {
            _context.CandidateSkillRatings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task<CandidateSkillRating> UpdateRating(CandidateSkillRating rating)
        {
            _context.CandidateSkillRatings.Update(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task<bool> DeleteRating(int id)
        {
            var rating = await _context.CandidateSkillRatings.FindAsync(id);
            if (rating == null) return false;

            _context.CandidateSkillRatings.Remove(rating);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}