using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository.Impl
{
    public class VerificationRepository : IVerificationRepository
    {
        private readonly AppDbContext _context;

        public VerificationRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Verification>> GetAllAsync() => await _context.Verifications.ToListAsync();

        public async Task<Verification> GetByIdAsync(int id) => await _context.Verifications.FindAsync(id);

        public async Task AddAsync(Verification verification)
        {
            await _context.Verifications.AddAsync(verification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Verification verification)
        {
            _context.Verifications.Update(verification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var verification = await GetByIdAsync(id);
            if (verification != null)
            {
                _context.Verifications.Remove(verification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Verification> GetByApplicationIDAsync(int applicationId)
        {
            return await _context.Verifications.FirstOrDefaultAsync(v => v.ApplicationID == applicationId);
        }

        
    }
}
