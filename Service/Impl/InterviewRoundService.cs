using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class InterviewRoundService : IInterviewRoundService
    {
        private readonly IInterviewRoundRepository _repository;

        public InterviewRoundService(IInterviewRoundRepository repository) => _repository = repository;

        public async Task<IEnumerable<InterviewRound>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<InterviewRound> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<InterviewRound>> GetInterviewRoundsByJobID(int jobId) =>
            await _repository.GetInterviewRoundsByJobID(jobId);

        public async Task AddAsync(InterviewRoundDTO interviewRoundDTO)
        {
            if (!await _repository.IsValidJobID(interviewRoundDTO.JobID))
                throw new ArgumentException("Invalid Job ID.");

            if (!await _repository.IsValidRoundMasterID(interviewRoundDTO.RoundMasterID))
                throw new ArgumentException("Invalid Round Master ID.");

            var interviewRound = new InterviewRound
            {
                RoundMasterID = interviewRoundDTO.RoundMasterID,
                JobID = interviewRoundDTO.JobID,
                SequenceOrder = interviewRoundDTO.SequenceOrder,
                IsFinalRound = interviewRoundDTO.IsFinalRound
            };

            await _repository.AddAsync(interviewRound);
        }

        public async Task UpdateAsync(int id, InterviewRoundDTO interviewRoundDTO)
        {
            var existingRound = await _repository.GetByIdAsync(id);
            if (existingRound == null)
                throw new KeyNotFoundException("Interview Round not found.");

            if (!await _repository.IsValidJobID(interviewRoundDTO.JobID))
                throw new ArgumentException("Invalid Job ID.");

            if (!await _repository.IsValidRoundMasterID(interviewRoundDTO.RoundMasterID))
                throw new ArgumentException("Invalid Round Master ID.");

            existingRound.RoundMasterID = interviewRoundDTO.RoundMasterID;
            existingRound.JobID = interviewRoundDTO.JobID;
            existingRound.SequenceOrder = interviewRoundDTO.SequenceOrder;
            existingRound.IsFinalRound = interviewRoundDTO.IsFinalRound;

            await _repository.UpdateAsync(existingRound);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
