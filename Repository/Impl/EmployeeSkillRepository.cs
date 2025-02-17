using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class EmployeeSkillRepository : IEmployeeSkillRepository
    {
        private readonly AppDbContext _context;

        public EmployeeSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeSkill>> GetAllEmployeeSkills()
        {
            return await _context.EmployeeSkills.Include(es => es.Employee).Include(es => es.Skill).ToListAsync();
        }

        public async Task<EmployeeSkill> GetEmployeeSkillById(int id)
        {
            return await _context.EmployeeSkills.Include(es => es.Employee).Include(es => es.Skill)
                .FirstOrDefaultAsync(es => es.EmployeeSkillID == id);
        }

        public async Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeId(int employeeId)
        {
            return await _context.EmployeeSkills.Include(es => es.Skill)
                .Where(es => es.EmployeeID == employeeId).ToListAsync();
        }

        public async Task<EmployeeSkill> AddEmployeeSkill(EmployeeSkill employeeSkill)
        {
            _context.EmployeeSkills.Add(employeeSkill);
            await _context.SaveChangesAsync();
            return employeeSkill;
        }

        public async Task<bool> DeleteEmployeeSkill(int id)
        {
            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null) return false;

            _context.EmployeeSkills.Remove(employeeSkill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
