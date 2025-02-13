using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
namespace RecruitmentSystem.Repository.Impl
{
    public class HiringDriveRepository : IHiringDriveRepository
    {
        private readonly AppDbContext _context;
        public HiringDriveRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<HiringDrive>> GetAllAsync() => await _context.HiringDrives.ToListAsync();

        public async Task<HiringDrive> GetByIdAsync(int id) =>
            await _context.HiringDrives.FindAsync(id);

        public async Task AddAsync(HiringDrive hiringDrive)
        {
            await _context.HiringDrives.AddAsync(hiringDrive);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HiringDrive hiringDrive)
        {
            _context.HiringDrives.Update(hiringDrive);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hiringDrive = await GetByIdAsync(id);
            if (hiringDrive != null)
            {
                _context.HiringDrives.Remove(hiringDrive);
                await _context.SaveChangesAsync();
            }
        }
    }
}