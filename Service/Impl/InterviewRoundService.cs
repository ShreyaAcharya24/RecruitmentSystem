using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service.Impl
{
    public class InterviewRoundService : IInterviewRoundService
    {
        private readonly IInterviewRoundRepository _interviewRoundRepository;

        public InterviewRoundService(IInterviewRoundRepository repository)
        {
            _interviewRoundRepository = repository;
        }

        public async Task<IEnumerable<InterviewRound>> GetAllAsync()
        {
            return await _interviewRoundRepository.GetAllAsync();
        }

        public async Task<InterviewRound> GetByIdAsync(int id)
        {
            return await _interviewRoundRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(InterviewRound round)
        {
            await _interviewRoundRepository.AddAsync(round);
        }

        public async Task UpdateAsync(InterviewRound round)
        {
            await _interviewRoundRepository.UpdateAsync(round);
        }

        public async Task DeleteAsync(int id)
        {
            await _interviewRoundRepository.DeleteAsync(id);
        }
    }
}
