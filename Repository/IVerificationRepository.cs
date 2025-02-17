using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IVerificationRepository
    {
        Task<IEnumerable<Verification>> GetAllAsync();
        Task<Verification> GetByIdAsync(int id);
        Task AddAsync(Verification verification);
        Task UpdateAsync(Verification verification);
        Task DeleteAsync(int id);
        Task<Verification> GetByApplicationIDAsync(int applicationId);
    }
}
