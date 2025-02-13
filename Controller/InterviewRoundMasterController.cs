using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;
namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewRoundMasterController : ControllerBase
    {
        private readonly IInterviewRoundMasterService _service;
        public InterviewRoundMasterController(IInterviewRoundMasterService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterviewRoundMaster roundMaster)
        {
            await _service.AddAsync(roundMaster);
            return CreatedAtAction(nameof(GetById), new { id = roundMaster.RoundID }, roundMaster);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InterviewRoundMaster roundMaster)
        {
            if (id != roundMaster.RoundID) return BadRequest();
            await _service.UpdateAsync(roundMaster);
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
