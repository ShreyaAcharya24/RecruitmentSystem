using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IInterviewRoundMasterService
    {
        Task<IEnumerable<InterviewRoundMaster>> GetAllAsync();
        Task<InterviewRoundMaster> GetByIdAsync(int id);
        Task AddAsync(InterviewRoundMaster roundMaster);
        Task UpdateAsync(InterviewRoundMaster roundMaster);
        Task DeleteAsync(int id);
    }
}

