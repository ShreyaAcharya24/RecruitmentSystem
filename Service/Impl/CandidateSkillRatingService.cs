using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service.Impl
{
    public class CandidateSkillRatingService : ICandidateSkillRatingService
    {
        private readonly ICandidateSkillRatingRepository _ratingRepository;

        public CandidateSkillRatingService(ICandidateSkillRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<CandidateSkillRatingResponseDTO>> GetAllRatings()
        {
            var ratings = await _ratingRepository.GetAllRatings();
            return ratings.Select(r => new CandidateSkillRatingResponseDTO
            {
                RateID = r.RateID,
                ApplicationID = r.ApplicationID,
                JobSkillID = r.JobSkillID,
                Rating = r.Rating
            }).ToList();
        }

        public async Task<CandidateSkillRatingResponseDTO> GetRatingById(int id)
        {
            var rating = await _ratingRepository.GetRatingById(id);
            if (rating == null) return null;

            return new CandidateSkillRatingResponseDTO
            {
                RateID = rating.RateID,
                ApplicationID = rating.ApplicationID,
                JobSkillID = rating.JobSkillID,
                Rating = rating.Rating
            };
        }

        public async Task<CandidateSkillRatingResponseDTO> AddRating(CandidateSkillRatingCreateDTO ratingDto)
        {
            var rating = new CandidateSkillRating
            {
                ApplicationID = ratingDto.ApplicationID,
                JobSkillID = ratingDto.JobSkillID,
                Rating = ratingDto.Rating
            };

            var createdRating = await _ratingRepository.AddRating(rating);
            return new CandidateSkillRatingResponseDTO
            {
                RateID = createdRating.RateID,
                ApplicationID = createdRating.ApplicationID,
                JobSkillID = createdRating.JobSkillID,
                Rating = createdRating.Rating
            };
        }

        public async Task<CandidateSkillRatingResponseDTO> UpdateRating(int id, CandidateSkillRatingCreateDTO ratingDto)
        {
            var rating = await _ratingRepository.GetRatingById(id);
            if (rating == null) return null;

            rating.ApplicationID = ratingDto.ApplicationID;
            rating.JobSkillID = ratingDto.JobSkillID;
            rating.Rating = ratingDto.Rating;

            var updatedRating = await _ratingRepository.UpdateRating(rating);
            return new CandidateSkillRatingResponseDTO
            {
                RateID = updatedRating.RateID,
                ApplicationID = updatedRating.ApplicationID,
                JobSkillID = updatedRating.JobSkillID,
                Rating = updatedRating.Rating
            };
        }

        public async Task<bool> DeleteRating(int id)
        {
            return await _ratingRepository.DeleteRating(id);
        }
    }
}