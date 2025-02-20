using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;
namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HiringDriveController : ControllerBase
    {
        private readonly IHiringDriveService _service;
        public HiringDriveController(IHiringDriveService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HiringDriveDto hiringDriveDto)
        {
            await _service.AddAsync(hiringDriveDto);
            return Ok(new { Message = "Hiring Drive Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HiringDriveDto hiringDriveDto)
        {
            await _service.UpdateAsync(id, hiringDriveDto);
            return Ok(new { Message = "Hiring Drive Updated Successfully" });
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new {Message = "Drive Deleted Successfully"});
        }
    }
}