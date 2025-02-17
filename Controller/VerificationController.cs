using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly IVerificationService _service;

        public VerificationController(IVerificationService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var verification = await _service.GetByIdAsync(id);
            return verification != null ? Ok(verification) : NotFound(new { message = "Verification not found" });
        }

        [HttpPost("{applicationId}")]
        public async Task<IActionResult> AddVerification(int applicationId)
        {
            await _service.AddVerification(applicationId);
            return Ok(new { message = "Verification record created successfully" });
        }


        [HttpPost("{applicationId}/upload-document")]
        public async Task<IActionResult> UploadDocument(int applicationId, IFormFile file)
        {
            try
            {
                string result = await _service.UploadDocument(applicationId, file);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpGet("{verificationId}/view-document")]
        public async Task<IActionResult> ViewDocument(int verificationId)
        {
            try
            {
                string filePath = await _service.GetVerificationDocumentPath(verificationId);

                if (!System.IO.File.Exists(filePath))
                    return NotFound(new { message = "File not found" });

                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(fileBytes, "application/pdf", Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }



        [HttpPatch("{verificationId}/status")]
        public async Task<IActionResult> UpdateVerificationStatus(int verificationId, [FromBody] UpdateVerificationDTO dto)
        {
            try
            {
                bool success = await _service.UpdateVerificationStatus(verificationId, dto);
                if (!success) return NotFound(new { message = "Verification not found" });

                return Ok(new { message = "Verification status updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
