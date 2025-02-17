using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<Feedback> GetByIdAsync(int id);
        Task AddAsync(FeedbackDTO feedbackDTO);
        Task UpdateAsync(int id, FeedbackDTO feedbackDTO);
        Task DeleteAsync(int id);
    }
}
