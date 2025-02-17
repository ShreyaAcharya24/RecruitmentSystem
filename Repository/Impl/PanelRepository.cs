using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository.Impl
{
    public class PanelRepository : IPanelRepository
    {
        private readonly AppDbContext _context;

        public PanelRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Panel>> GetAllAsync() => await _context.Panels.ToListAsync();

        public async Task<Panel> GetByIdAsync(int id) => await _context.Panels.FindAsync(id);

        public async Task<IEnumerable<Panel>> GetInterviewRoundsByEmployeeID(int employeeId) =>
            await _context.Panels.Where(p => p.InterviewerID == employeeId).ToListAsync();

        public async Task AddAsync(Panel panel)
        {
            await _context.Panels.AddAsync(panel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Panel panel)
        {
            _context.Panels.Update(panel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var panel = await GetByIdAsync(id);
            if (panel != null)
            {
                _context.Panels.Remove(panel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsValidInterviewRoundID(int interviewRoundId) => 
            await _context.InterviewRounds.AnyAsync(ir => ir.InterviewRoundID == interviewRoundId);

        public async Task<bool> IsValidEmployeeID(int employeeId) => 
            await _context.Employees.AnyAsync(e => e.EmployeeID == employeeId);
    }
}
