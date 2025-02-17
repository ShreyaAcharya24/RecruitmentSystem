using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _repository;

        public InterviewService(IInterviewRepository repository) => _repository = repository;

        public async Task<IEnumerable<Interview>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Interview> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Interview>> GetInterviewsByCandidateID(int candidateId) =>
            await _repository.GetInterviewsByCandidateID(candidateId);

        public async Task<IEnumerable<Interview>> GetInterviewsByJobID(int jobId) =>
            await _repository.GetInterviewsByJobID(jobId);

        public async Task<IEnumerable<Interview>> GetInterviewsByPanelID(int panelId) =>
            await _repository.GetInterviewsByPanelID(panelId);

        public async Task<IEnumerable<Interview>> GetUpcomingInterviews() =>
            await _repository.GetUpcomingInterviews();

        public async Task<IEnumerable<Interview>> GetCompletedInterviews() =>
            await _repository.GetCompletedInterviews();

        public async Task<IEnumerable<Interview>> GetFailedInterviews() =>
            await _repository.GetFailedInterviews();

        public async Task<IEnumerable<Interview>> GetPassedInterviews() =>
            await _repository.GetPassedInterviews();

        public async Task AddAsync(InterviewDTO interviewDTO)
        {
            var interview = new Interview
            {
                ApplicationID = interviewDTO.ApplicationID,
                InterviewRoundID = interviewDTO.InterviewRoundID,
                PanelID = interviewDTO.PanelID,
                DateTime = interviewDTO.DateTime,
                Status = interviewDTO.Status,
                InterviewFeedback = interviewDTO.InterviewFeedback
            };

            await _repository.AddAsync(interview);
        }

        public async Task UpdateAsync(int id, UpdateInterviewStatusDTO updateDTO)
        {
            var existingInterview = await _repository.GetByIdAsync(id);
            if (existingInterview == null)
                throw new KeyNotFoundException("Interview not found.");

            existingInterview.Status = updateDTO.Status;
            existingInterview.PassStatus = updateDTO.PassStatus;

            await _repository.UpdateAsync(existingInterview);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
