using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            return feedback != null ? Ok(feedback) : NotFound(new { message = "Feedback not found" });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FeedbackDTO feedbackDTO)
        {
            await _service.AddAsync(feedbackDTO);
            return Ok(new { message = "Feedback Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FeedbackDTO feedbackDTO)
        {
            await _service.UpdateAsync(id, feedbackDTO);
            return Ok(new { message = "Feedback Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
