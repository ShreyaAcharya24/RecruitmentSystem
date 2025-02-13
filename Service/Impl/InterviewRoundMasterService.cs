using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class InterviewRoundMasterService : IInterviewRoundMasterService
    {
        private readonly IInterviewRoundMasterRepository _repository;
        public InterviewRoundMasterService(IInterviewRoundMasterRepository repository) => _repository = repository;

        public async Task<IEnumerable<InterviewRoundMaster>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<InterviewRoundMaster> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(InterviewRoundMaster roundMaster) => await _repository.AddAsync(roundMaster);
        public async Task UpdateAsync(InterviewRoundMaster roundMaster) => await _repository.UpdateAsync(roundMaster);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}