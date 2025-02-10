using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillController : ControllerBase
    {
        private readonly IEmployeeSkillService _employeeSkillService;

        public EmployeeSkillController(IEmployeeSkillService employeeSkillService)
        {
            _employeeSkillService = employeeSkillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeSkillService.GetAllEmployeeSkills());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _employeeSkillService.GetEmployeeSkillById(id));
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeId(int employeeId)
        {
            return Ok(await _employeeSkillService.GetSkillsByEmployeeId(employeeId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeSkill employeeSkill)
        {
            return Ok(await _employeeSkillService.AddEmployeeSkill(employeeSkill));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _employeeSkillService.DeleteEmployeeSkill(id));
        }

        
    }
}
