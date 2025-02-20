using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly CandidateExcelService _candidateExcelService;

        public CandidateController(ICandidateService candidateService, CandidateExcelService candidateExcelService)
        {
            _candidateService = candidateService;
            _candidateExcelService = candidateExcelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _candidateService.GetAllCandidates());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _candidateService.GetCandidateById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Candidate candidate, IFormFile resumeFile)
        {

            var result = await _candidateService.AddCandidate(candidate, resumeFile);
            return CreatedAtAction(nameof(GetById), new { id = result.CandidateID }, result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Candidate candidate)
        {
            return Ok(await _candidateService.UpdateCandidate(candidate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _candidateService.DeleteCandidate(id);
            return deleted ? Ok(new { message = "Candidate deleted successfully." }) : NotFound(new { message = "Candidate not found." });
        }

        [HttpGet("downloadResume/{id}")]
        public async Task<IActionResult> DownloadResume(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null || string.IsNullOrEmpty(candidate.Resume))
                return NotFound(new { message = "Resume not found for this candidate" });

            var filePath = candidate.Resume;
            if (!System.IO.File.Exists(filePath))
                return NotFound(new { message = "Resume file not found on the server" });

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, contentType, Path.GetFileName(filePath));
        }

        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUploadCandidates(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var result = await _candidateExcelService.BulkInsertCandidatesFromExcelAsync(file);
            return Ok(result);
        }
    }
}
