using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Repository.Impl
{
    public class SkillCategoryRepository : ISkillCategoryRepository
    {
        private readonly AppDbContext _context;

        public SkillCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SkillCategory>> GetAllCategories()
        {
            return await _context.SkillCategories.ToListAsync();
        }

        public async Task<SkillCategory> GetCategoryById(int id)
        {
            return await _context.SkillCategories.FindAsync(id);
        }

        public async Task<SkillCategory> AddCategory(SkillCategory category)
        {
            _context.SkillCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<SkillCategory> UpdateCategory(SkillCategory category)
        {
            _context.SkillCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.SkillCategories.FindAsync(id);
            if (category == null) return false;

            _context.SkillCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
