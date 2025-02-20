using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _skillService.GetAllSkills());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            if (skill == null) return NotFound(new { message = "Skill not found" });
            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Skill skill)
        {
            return Ok(await _skillService.AddSkill(skill));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Skill skill)
        {
            if (id != skill.SkillID) return BadRequest(new { message = "ID mismatch" });
            return Ok(await _skillService.UpdateSkill(skill));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _skillService.DeleteSkill(id);
            return deleted ? Ok(new { message = "Deleted successfully" }) : NotFound(new { message = "Skill deletion failed" });
        }
    }
}
