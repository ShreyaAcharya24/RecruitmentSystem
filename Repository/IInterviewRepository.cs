using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IInterviewRepository
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
        Task AddAsync(Interview interview);
        Task UpdateAsync(Interview interview);
        Task DeleteAsync(int id);
    }
}
