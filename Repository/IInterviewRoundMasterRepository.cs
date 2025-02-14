using RecruitmentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
