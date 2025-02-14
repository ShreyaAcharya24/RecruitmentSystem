using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Repository.Impl
{
    public class InterviewRoundMasterRepository : IInterviewRoundMasterRepository
    {
        private readonly AppDbContext _context;

        public InterviewRoundMasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InterviewRoundMaster>> GetAllAsync()
        {
            return await _context.InterviewRoundMasters.ToListAsync();
        }

        public async Task<InterviewRoundMaster> GetByIdAsync(int id)
        {
            return await _context.InterviewRoundMasters.FindAsync(id);
        }

        public async Task AddAsync(InterviewRoundMaster roundMaster)
        {
            await _context.InterviewRoundMasters.AddAsync(roundMaster);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InterviewRoundMaster roundMaster)
        {
            _context.InterviewRoundMasters.Update(roundMaster);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roundMaster = await _context.InterviewRoundMasters.FindAsync(id);
            if (roundMaster != null)
            {
                _context.InterviewRoundMasters.Remove(roundMaster);
                await _context.SaveChangesAsync();
            }
        }
    }
}
