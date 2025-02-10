using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobReviewerController : ControllerBase
    {
        private readonly IJobReviewerService _jobReviewerService;

        public JobReviewerController(IJobReviewerService jobReviewerService)
        {
            _jobReviewerService = jobReviewerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobReviews()
        {
            return Ok(await _jobReviewerService.GetAllJobReviews());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _jobReviewerService.GetJobReviewsById(id));
        }

        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetByJobId(int jobId)
        {
            return Ok(await _jobReviewerService.GetJobReviewsByJobId(jobId));
        }

         [HttpGet("reviewer/{reviewerId}")]
        public async Task<IActionResult> GetByReviewerId(int reviewerId)
        {
            return Ok(await _jobReviewerService.GetJobReviewsByReviewerId(reviewerId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobReviwer jobReviwer)
        {
            return Ok(await _jobReviewerService.AddJobReviewer(jobReviwer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _jobReviewerService.DeleteJobReviewer(id));
        }

        
    }
}
