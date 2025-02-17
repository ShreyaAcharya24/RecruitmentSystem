using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;


namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromBody] Application application)
        {
            var result = await _applicationService.SubmitApplication(application);
            return Ok(new { message = "Application submitted", application = result });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await _applicationService.GetAllApplications());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var application = await _applicationService.GetApplicationById(id);
            if (application == null) return NotFound(new { message = "Application not found" });
            return Ok(application);
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetApplicationsByCandidate(int candidateId)
        {
            return Ok(await _applicationService.GetApplicationsByCandidate(candidateId));
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateApplicationStatus(int id, [FromBody] ApplicationStatus status)
        {
            var success = await _applicationService.UpdateApplicationStatus(id, status);
            if (!success) return NotFound(new { message = "Application not found" });
            return Ok(new { message = "Application status updated" });
        }

        [HttpPatch("{applicationId}/assign-reviewer/{reviewerId}")]
        public async Task<IActionResult> AssignReviewerToApplication(int applicationId, int reviewerId)
        {
            var success = await _applicationService.AssignReviewerToApplication(applicationId, reviewerId);
            if (!success) return NotFound(new { message = "Application not found or reviewer invalid" });

            return Ok(new { message = "Reviewer assigned successfully" });
        }
    }
}
