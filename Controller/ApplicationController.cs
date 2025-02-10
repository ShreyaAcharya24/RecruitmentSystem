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

        public ApplicationController(IJobService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _applicationService.GetAllApplications());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _applicationService.GetApplicationById(id);
            if (application == null) return NotFound(new { message = "Application not found" });
            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Application application)
        {
            return Ok(await _applicationService.AddApplication(application));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Application application)
        {
            if (id != application.ApplicationID) return BadRequest();
            return Ok(await _applicationService.UpdateApplication(application));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _applicationService.DeleteApplication(id));
        }

       
    }
}
