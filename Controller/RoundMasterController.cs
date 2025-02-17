using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundMasterController : ControllerBase
    {
        private readonly IRoundMasterService _service;

        public RoundMasterController(IRoundMasterService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RoundMasterDTO roundMasterDTO)
        {
            await _service.AddAsync(roundMasterDTO);
            return Ok(new { Message = "Round Master Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoundMasterDTO roundMasterDTO)
        {
            await _service.UpdateAsync(id, roundMasterDTO);
            return Ok(new { Message = "Round Master Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
