using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterviewRound interviewRound)
        {
            await _service.AddAsync(interviewRound);
            return CreatedAtAction(nameof(GetById), new { id = interviewRound.InterviewRoundID }, interviewRound);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InterviewRound interviewRound)
        {
            if (id != interviewRound.InterviewRoundID) return BadRequest();
            await _service.UpdateAsync(interviewRound);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}