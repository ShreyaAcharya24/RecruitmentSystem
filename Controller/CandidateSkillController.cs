using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class CandidateSkillController : ControllerBase
    {
        private readonly ICandidateSkillService _candidateSkillService;
        private readonly ICandidateService _candidateService;
        private readonly ISkillService _skillService;


        public CandidateSkillController(ICandidateSkillService candidateSkillService,ICandidateService candidateService,ISkillService skillService)
        {
            _candidateSkillService = candidateSkillService;
            _candidateService = candidateService;
            _skillService = skillService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _candidateSkillService.GetAllCandidateSkills());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _candidateSkillService.GetCandidateSkillById(id));
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetByCandidateId(int candidateId)
        {
            return Ok(await _candidateSkillService.GetSkillsByCandidateId(candidateId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CandidateSkill candidateSkill)
        {
            
            if (!await _candidateService.DoesCandidateExistAsync(candidateSkill.CandidateID)){
                return NotFound(new {message = "Invalid Candidate ID"});
            }

            if (!await _skillService.DoesSkillExistAsync(candidateSkill.SkillID)){
                return NotFound(new {message = "Invalid Skill ID"});
            }
            
            await _candidateSkillService.AddCandidateSkill(candidateSkill);
           
                return Ok(new {messsage = "Candidate skill added successfully"});
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _candidateSkillService.DeleteCandidateSkill(id));
        }

        
    }
}
