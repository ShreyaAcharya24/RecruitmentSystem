using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<Candidate> AddCandidate(Candidate candidate);
        Task<Candidate> UpdateCandidate(Candidate candidate);
        Task<bool> DeleteCandidate(int id);

         Task<bool> DoesCandidateExistAsync(int id);
    }
}
