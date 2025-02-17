using RecruitmentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Repository
{
    public interface ICandidateSkillRatingRepository
    {
        Task<IEnumerable<CandidateSkillRating>> GetAllRatings();
        Task<CandidateSkillRating> GetRatingById(int id);
        Task<CandidateSkillRating> AddRating(CandidateSkillRating rating);
        Task<CandidateSkillRating> UpdateRating(CandidateSkillRating rating);
        Task<bool> DeleteRating(int id);
    }
}