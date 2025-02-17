using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IRoundMasterRepository
    {
        Task<IEnumerable<RoundMaster>> GetAllAsync();
        Task<RoundMaster> GetByIdAsync(int id);
        Task AddAsync(RoundMaster roundMaster);
        Task UpdateAsync(RoundMaster roundMaster);
        Task DeleteAsync(int id);
    }
}
