using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository.Impl
{
    public class InterviewRoundRepository : IInterviewRoundRepository
    {
        private readonly AppDbContext _context;

        public InterviewRoundRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<InterviewRound>> GetAllAsync() => await _context.InterviewRounds.ToListAsync();

        public async Task<InterviewRound> GetByIdAsync(int id) => await _context.InterviewRounds.FindAsync(id);

        public async Task<IEnumerable<InterviewRound>> GetInterviewRoundsByJobID(int jobId) =>
            await _context.InterviewRounds.Where(ir => ir.JobID == jobId).ToListAsync();

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
            if (interviewRound == null)
                throw new KeyNotFoundException("Interview Round not found.");

            // If there are any Interviews linked --> Stop delete 
            bool hasInterviews = await _context.Interviews.AnyAsync(i => i.InterviewRoundID == id);
            if (hasInterviews)
                throw new InvalidOperationException("Cannot delete Interview Round because interviews are associated with it.");

            //If no interviews --> allow deletion
            _context.InterviewRounds.Remove(interviewRound);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> IsValidJobID(int jobId) => await _context.Jobs.AnyAsync(j => j.JobID == jobId);

        public async Task<bool> IsValidRoundMasterID(int roundMasterId) => await _context.RoundMasters.AnyAsync(rm => rm.RoundMasterID == roundMasterId);
    }
}
