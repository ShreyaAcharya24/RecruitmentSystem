using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository.Impl
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly AppDbContext _context;

        public InterviewRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Interview>> GetAllAsync() => await _context.Interviews.ToListAsync();

        public async Task<Interview> GetByIdAsync(int id) => await _context.Interviews.FindAsync(id);

        public async Task<IEnumerable<Interview>> GetInterviewsByCandidateID(int candidateId) =>
            await _context.Interviews.Where(i => i.Application.CandidateID == candidateId).ToListAsync();

        public async Task<IEnumerable<Interview>> GetInterviewsByJobID(int jobId) =>
            await _context.Interviews.Where(i => i.Application.JobID == jobId).ToListAsync();

        public async Task<IEnumerable<Interview>> GetInterviewsByPanelID(int panelId) =>
            await _context.Interviews.Where(i => i.PanelID == panelId).ToListAsync();

        public async Task<IEnumerable<Interview>> GetUpcomingInterviews() =>
            await _context.Interviews.Where(i => i.Status == InterviewStatus.Scheduled).ToListAsync();

        public async Task<IEnumerable<Interview>> GetCompletedInterviews() =>
            await _context.Interviews.Where(i => i.Status == InterviewStatus.Completed).ToListAsync();

        public async Task<IEnumerable<Interview>> GetFailedInterviews() => 
            await _context.Interviews
                .Where(i => i.PassStatus.HasValue && i.PassStatus.Value == PassStatus.Failed)
                .ToListAsync();

        public async Task<IEnumerable<Interview>> GetPassedInterviews() =>
            await _context.Interviews
                .Where(i => i.PassStatus.HasValue && i.PassStatus.Value == PassStatus.Passed)
                .ToListAsync();


        public async Task AddAsync(Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Interview interview)
        {
            _context.Interviews.Update(interview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var interview = await GetByIdAsync(id);
            if (interview != null)
            {
                _context.Interviews.Remove(interview);
                await _context.SaveChangesAsync();
            }
        }
    }
}
