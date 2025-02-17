using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        private readonly IPanelService _service;

        public PanelController(IPanelService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetInterviewRoundsByEmployeeID(int employeeId)
        {
            var rounds = await _service.GetInterviewRoundsByEmployeeID(employeeId);
            return Ok(rounds);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PanelDTO panelDTO)
        {
            await _service.AddAsync(panelDTO);
            return Ok(new { Message = "Panel Assigned Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PanelDTO panelDTO)
        {
            await _service.UpdateAsync(id, panelDTO);
            return Ok(new { Message = "Panel Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
