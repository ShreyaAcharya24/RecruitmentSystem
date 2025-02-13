using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IInterviewRoundMasterRepository
    {
        Task<IEnumerable<InterviewRoundMaster>> GetAllAsync();
        Task<InterviewRoundMaster> GetByIdAsync(int id);
        Task AddAsync(InterviewRoundMaster roundMaster);
        Task UpdateAsync(InterviewRoundMaster roundMaster);
        Task DeleteAsync(int id);
    }
}