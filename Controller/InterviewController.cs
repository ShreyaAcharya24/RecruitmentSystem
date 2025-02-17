using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _service;

        public InterviewController(IInterviewService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var interview = await _service.GetByIdAsync(id);
            return interview != null ? Ok(interview) : NotFound(new { message = "Interview not found" });
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetInterviewsByCandidateID(int candidateId)
        {
            var interviews = await _service.GetInterviewsByCandidateID(candidateId);
            return Ok(interviews);
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetInterviewsByJobID(int jobId)
        {
            var interviews = await _service.GetInterviewsByJobID(jobId);
            return Ok(interviews);
        }

        [HttpGet("panel/{panelId}")]
        public async Task<IActionResult> GetInterviewsByPanelID(int panelId)
        {
            var interviews = await _service.GetInterviewsByPanelID(panelId);
            return Ok(interviews);
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingInterviews()
        {
            var interviews = await _service.GetUpcomingInterviews();
            return Ok(interviews);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedInterviews()
        {
            var interviews = await _service.GetCompletedInterviews();
            return Ok(interviews);
        }

        [HttpGet("failed")]
        public async Task<IActionResult> GetFailedInterviews()
        {
            var interviews = await _service.GetFailedInterviews();
            return Ok(interviews);
        }

        [HttpGet("passed")]
        public async Task<IActionResult> GetPassedInterviews()
        {
            var interviews = await _service.GetPassedInterviews();
            return Ok(interviews);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterviewDTO interviewDTO)
        {
            await _service.AddAsync(interviewDTO);
            return Ok(new { message = "Interview Created Successfully" });
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateInterviewStatus(int id, [FromBody] UpdateInterviewStatusDTO updateDTO)
        {
            await _service.UpdateAsync(id, updateDTO);
            return Ok(new { message = "Interview Status Updated Successfully" });
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
