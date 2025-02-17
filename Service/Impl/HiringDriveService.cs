using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class HiringDriveService : IHiringDriveService
    {
        private readonly IHiringDriveRepository _repository;
        public HiringDriveService(IHiringDriveRepository repository) => _repository = repository;

        public async Task<IEnumerable<HiringDrive>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<HiringDrive> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(HiringDriveDto hiringDriveDto){
            var hiringDrive = new HiringDrive
        {
            DriveName = hiringDriveDto.DriveName,
            Year = hiringDriveDto.Year,
            StartDate = hiringDriveDto.StartDate,
            EndDate = hiringDriveDto.EndDate,
            Location = hiringDriveDto.Location
        };
        await _repository.AddAsync(hiringDrive);
        }
         public async Task UpdateAsync(int id, HiringDriveDto hiringDriveDto)
    {
        var existingHiringDrive = await _repository.GetByIdAsync(id);
        if (existingHiringDrive == null)
        {
            throw new KeyNotFoundException("Hiring Drive not found.");
        }

        existingHiringDrive.DriveName = hiringDriveDto.DriveName;
        existingHiringDrive.Year = hiringDriveDto.Year;
        existingHiringDrive.StartDate = hiringDriveDto.StartDate;
        existingHiringDrive.EndDate = hiringDriveDto.EndDate;
        existingHiringDrive.Location = hiringDriveDto.Location;

        await _repository.UpdateAsync(existingHiringDrive);
    }
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}