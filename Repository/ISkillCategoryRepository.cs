using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface ISkillCategoryRepository
    {
        Task<IEnumerable<SkillCategory>> GetAllCategories();
        Task<SkillCategory> GetCategoryById(int id);
        Task<SkillCategory> AddCategory(SkillCategory category);
        Task<SkillCategory> UpdateCategory(SkillCategory category);
        Task<bool> DeleteCategory(int id);
    }
}
