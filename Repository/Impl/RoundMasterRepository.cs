using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository.Impl
{
    public class RoundMasterRepository : IRoundMasterRepository
    {
        private readonly AppDbContext _context;

        public RoundMasterRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<RoundMaster>> GetAllAsync() => await _context.RoundMasters.ToListAsync();

        public async Task<RoundMaster> GetByIdAsync(int id) => await _context.RoundMasters.FindAsync(id);

        public async Task AddAsync(RoundMaster roundMaster)
        {
            await _context.RoundMasters.AddAsync(roundMaster);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoundMaster roundMaster)
        {
            _context.RoundMasters.Update(roundMaster);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roundMaster = await GetByIdAsync(id);
            if (roundMaster != null)
            {
                _context.RoundMasters.Remove(roundMaster);
                await _context.SaveChangesAsync();
            }
        }
    }
}
