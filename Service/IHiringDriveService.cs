using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IHiringDriveService
    {
        Task<IEnumerable<HiringDrive>> GetAllAsync();
        Task<HiringDrive> GetByIdAsync(int id);
        Task AddAsync(HiringDriveDto hiringDriveDto);
        Task UpdateAsync(int id, HiringDriveDto hiringDriveDto);
        Task DeleteAsync(int id);
    }
}