using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
namespace RecruitmentSystem.Repository.Impl
{
    public class InterviewRoundRepository : IInterviewRoundRepository
    {
        private readonly AppDbContext _context;
        public InterviewRoundRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<InterviewRound>> GetAllAsync() =>
            await _context.InterviewRounds.Include(ir => ir.Round).Include(ir => ir.Job).Include(ir => ir.HiringDrive).ToListAsync();

        public async Task<InterviewRound> GetByIdAsync(int id) =>
            await _context.InterviewRounds.FindAsync(id);

        public async Task AddAsync(InterviewRound interviewRound)
        {
            await _context.InterviewRounds.AddAsync(interviewRound);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InterviewRound interviewRound)
        {
            _context.InterviewRounds.Update(interviewRound);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var interviewRound = await GetByIdAsync(id);
            if (interviewRound != null)
            {
                _context.InterviewRounds.Remove(interviewRound);
                await _context.SaveChangesAsync();
            }
        }
    }
}