using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service
{
    public interface ICandidateSkillRatingService
    {
        Task<IEnumerable<CandidateSkillRatingResponseDTO>> GetAllRatings();
        Task<CandidateSkillRatingResponseDTO> GetRatingById(int id);
        Task<CandidateSkillRatingResponseDTO> AddRating(CandidateSkillRatingCreateDTO ratingDto);
        Task<CandidateSkillRatingResponseDTO> UpdateRating(int id, CandidateSkillRatingCreateDTO ratingDto);
        Task<bool> DeleteRating(int id);
    }
}