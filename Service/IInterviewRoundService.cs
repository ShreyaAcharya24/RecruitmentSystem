using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IInterviewRoundService
    {
        Task<IEnumerable<InterviewRound>> GetAllAsync();
        Task<InterviewRound> GetByIdAsync(int id);
        Task<IEnumerable<InterviewRound>> GetInterviewRoundsByJobID(int jobId);
        Task AddAsync(InterviewRoundDTO interviewRoundDTO);
        Task UpdateAsync(int id, InterviewRoundDTO interviewRoundDTO);
        Task DeleteAsync(int id);
    }
}
