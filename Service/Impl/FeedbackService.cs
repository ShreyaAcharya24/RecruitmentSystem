using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository) => _repository = repository;

        public async Task<IEnumerable<Feedback>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Feedback> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(FeedbackDTO feedbackDTO)
        {
            var feedback = new Feedback
            {
                InterviewID = feedbackDTO.InterviewID,
                Comments = feedbackDTO.Comments
            };

            await _repository.AddAsync(feedback);
        }

        public async Task UpdateAsync(int id, FeedbackDTO feedbackDTO)
        {
            var existingFeedback = await _repository.GetByIdAsync(id);
            if (existingFeedback == null)
                throw new KeyNotFoundException("Feedback not found.");

            existingFeedback.Comments = feedbackDTO.Comments;

            await _repository.UpdateAsync(existingFeedback);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
