using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateSkillRatingController : ControllerBase
    {
        private readonly ICandidateSkillRatingService _ratingService;

        public CandidateSkillRatingController(ICandidateSkillRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await _ratingService.GetAllRatings();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _ratingService.GetRatingById(id);
            if (rating == null) return NotFound();
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CandidateSkillRatingCreateDTO ratingDto)
        {
            var rating = await _ratingService.AddRating(ratingDto);
            return CreatedAtAction(nameof(GetById), new { id = rating.RateID }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CandidateSkillRatingCreateDTO ratingDto)
        {
            var rating = await _ratingService.UpdateRating(id, ratingDto);
            if (rating == null) return NotFound();
            return Ok(rating);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ratingService.DeleteRating(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}