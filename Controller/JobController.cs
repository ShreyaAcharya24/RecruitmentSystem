using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
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
            var jobs = await _jobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null) return NotFound(new { message = "Job not found" });

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JobCreateDTO jobDto)
        {
            await _jobService.AddJob(jobDto);
            return CreatedAtAction(nameof(GetById), new { id = jobDto.PostedBy }, jobDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobCreateDTO jobDto)
        {
            var updatedJob = await _jobService.UpdateJob(id, jobDto);
            if (updatedJob == null)
                return NotFound(new { message = "Job not found" });

            return Ok(updatedJob);
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


        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateJobStatus(int id, [FromBody] JobStatusUpdateDTO jobStatusUpdateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _jobService.UpdateJobStatus(id, jobStatusUpdateDTO.Status, jobStatusUpdateDTO.StatusReason);
            if (!success) return NotFound(new { message = "Job not found" });

            return Ok(new { message = "Job status updated successfully" });
        }


    }
}
