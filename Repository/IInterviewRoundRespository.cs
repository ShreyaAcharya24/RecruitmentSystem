using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IInterviewRoundRepository
    {
        Task<IEnumerable<InterviewRound>> GetAllAsync();
        Task<InterviewRound> GetByIdAsync(int id);
        Task<IEnumerable<InterviewRound>> GetInterviewRoundsByJobID(int jobId);
        Task AddAsync(InterviewRound interviewRound);
        Task UpdateAsync(InterviewRound interviewRound);
        Task DeleteAsync(int id);
        Task<bool> IsValidJobID(int jobId);
        Task<bool> IsValidRoundMasterID(int roundMasterId);
    }
}
