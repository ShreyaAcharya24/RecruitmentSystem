using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSkillController : ControllerBase
    {
        private readonly IJobSkillService _jobSkillService;

        public JobSkillController(IJobSkillService jobSkillService)
        {
            _jobSkillService = jobSkillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobSkillService.GetAllJobSkills());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _jobSkillService.GetJobSkillById(id));
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetByJobId(int jobId)
        {
            return Ok(await _jobSkillService.GetJobSkillsByJobId(jobId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobSkill jobSkill)
        {
            return Ok(await _jobSkillService.AddJobSkill(jobSkill));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _jobSkillService.DeleteJobSkill(id));
        }

        
    }
}
