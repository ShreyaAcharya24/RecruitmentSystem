using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            return await _context.Skills.Include(s => s.SkillCategory).ToListAsync();
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await _context.Skills.Include(s => s.SkillCategory).FirstOrDefaultAsync(s => s.SkillID == id);
        }

        public async Task<Skill> AddSkill(Skill skill)
        {

            var category = await _context.SkillCategories.FindAsync(skill.CategoryID);
            if (category == null)
            {
                throw new Exception("Invalid Category ID");
            }

             skill.SkillCategory = category; // Assign existing category
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill> UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }

         public async Task<bool> SkillExistsAsync(int id)
        {
            return await _context.Skills.AnyAsync(s => s.SkillID == id);
        }
    }
}
