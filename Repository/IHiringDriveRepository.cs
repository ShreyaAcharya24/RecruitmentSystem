using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IHiringDriveRepository
    {
        Task<IEnumerable<HiringDrive>> GetAllAsync();
        Task<HiringDrive> GetByIdAsync(int id);
        Task AddAsync(HiringDrive hiringDrive);
        Task UpdateAsync(HiringDrive hiringDrive);
        Task DeleteAsync(int id);
    }
}