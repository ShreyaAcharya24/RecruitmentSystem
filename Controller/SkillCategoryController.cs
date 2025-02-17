using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoryController : ControllerBase
    {
        private readonly ISkillCategoryService _skillCategoryService;

        public SkillCategoryController(ISkillCategoryService skillCategoryService)
        {
            _skillCategoryService = skillCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _skillCategoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _skillCategoryService.GetCategoryById(id);
            if (category == null) return NotFound(new { message = "Skill Category not found" });
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillCategory category)
        {
            return Ok(await _skillCategoryService.AddCategory(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SkillCategory category)
        {
            if (id != category.CategoryID) return BadRequest(new { message = "ID mismatch" });
            return Ok(await _skillCategoryService.UpdateCategory(category));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _skillCategoryService.DeleteCategory(id);
            if (!deleted) return NotFound(new { message = "Skill Category not found" });
            return Ok(new { message = "Deleted successfully" });
        }
    }
}
