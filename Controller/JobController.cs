using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobService.GetAllJobs());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null) return NotFound(new { message = "Job not found" });
            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Job job)
        {
            return Ok(await _jobService.AddJob(job));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Job job)
        {
            if (id != job.JobID) return BadRequest();
            return Ok(await _jobService.UpdateJob(job));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _jobService.DeleteJob(id));
        }

         [HttpGet("open")]
        public async Task<IActionResult> GetOpenJobs()
        {
            var openJobs = await _jobService.GetOpenJobs();
            if (!openJobs.Any())
            {
                return NotFound(new { message = "No open jobs found." });
            }
            return Ok(openJobs);
        }
    }
}
