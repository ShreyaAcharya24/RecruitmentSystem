using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class SkillCategoryService : ISkillCategoryService
    {
        private readonly ISkillCategoryRepository _repository;

        public SkillCategoryService(ISkillCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SkillCategory>> GetAllCategories() => await _repository.GetAllCategories();

        public async Task<SkillCategory> GetCategoryById(int id) => await _repository.GetCategoryById(id);

        public async Task<SkillCategory> AddCategory(SkillCategory category) => await _repository.AddCategory(category);

        public async Task<SkillCategory> UpdateCategory(SkillCategory category) => await _repository.UpdateCategory(category);

        public async Task<bool> DeleteCategory(int id) => await _repository.DeleteCategory(id);
    }
}
