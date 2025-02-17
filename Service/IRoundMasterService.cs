using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IRoundMasterService
    {
        Task<IEnumerable<RoundMaster>> GetAllAsync();
        Task<RoundMaster> GetByIdAsync(int id);
        Task AddAsync(RoundMasterDTO roundMasterDTO);
        Task UpdateAsync(int id, RoundMasterDTO roundMasterDTO);
        Task DeleteAsync(int id);
    }
}
