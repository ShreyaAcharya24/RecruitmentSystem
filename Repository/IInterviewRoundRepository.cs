using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IInterviewRoundRepository
    {
        Task<IEnumerable<InterviewRound>> GetAllAsync();
        Task<InterviewRound> GetByIdAsync(int id);
        Task AddAsync(InterviewRound interviewRound);
        Task UpdateAsync(InterviewRound interviewRound);
        Task DeleteAsync(int id);
    }
}
