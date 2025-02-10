using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
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
        public async Task<IActionResult> Create([FromBody] Candidate candidate)
        {
            try
            {
                var result = await _candidateService.AddCandidate(candidate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Candidate candidate)
        {
            if (id != candidate.CandidateID) return BadRequest();
            return Ok(await _candidateService.UpdateCandidate(candidate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _candidateService.DeleteCandidate(id));
        }
    }
}
