using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewRoundController : ControllerBase
    {
        private readonly IInterviewRoundService _service;

        public InterviewRoundController(IInterviewRoundService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetInterviewRoundsByJobID(int jobId)
        {
            var rounds = await _service.GetInterviewRoundsByJobID(jobId);
            return Ok(rounds);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterviewRoundDTO interviewRoundDTO)
        {
            await _service.AddAsync(interviewRoundDTO);
            return Ok(new { Message = "Interview Round Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InterviewRoundDTO interviewRoundDTO)
        {
            await _service.UpdateAsync(id, interviewRoundDTO);
            return Ok(new { Message = "Interview Round Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
