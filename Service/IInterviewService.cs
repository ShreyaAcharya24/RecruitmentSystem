using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IInterviewService
    {
        Task<IEnumerable<Interview>> GetAllAsync();
        Task<Interview> GetByIdAsync(int id);
        Task<IEnumerable<Interview>> GetInterviewsByCandidateID(int candidateId);
        Task<IEnumerable<Interview>> GetInterviewsByJobID(int jobId);
        Task<IEnumerable<Interview>> GetInterviewsByPanelID(int panelId);
        Task<IEnumerable<Interview>> GetUpcomingInterviews();
        Task<IEnumerable<Interview>> GetCompletedInterviews();
        Task<IEnumerable<Interview>> GetFailedInterviews();
        Task<IEnumerable<Interview>> GetPassedInterviews();
        Task AddAsync(InterviewDTO interviewDTO);
        Task UpdateAsync(int id, UpdateInterviewStatusDTO updateDTO);
        Task DeleteAsync(int id);
    }
}
