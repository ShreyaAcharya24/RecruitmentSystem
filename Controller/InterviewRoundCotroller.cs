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
        public InterviewRoundController(IInterviewRoundService service) {

          _service = service;

        } 

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterviewRound round)
        {
            await _service.AddAsync(round);
            return CreatedAtAction(nameof(GetById), new { id = round.RoundID }, round);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InterviewRound round)
        {
            if (id != round.RoundID) return BadRequest();
            await _service.UpdateAsync(round);
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
