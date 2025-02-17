using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<Candidate> AddCandidate(Candidate candidate);
        Task<Candidate> UpdateCandidate(Candidate candidate);
        Task<bool> DeleteCandidate(int id);

        Task<bool> CandidateExistsAsync(int id);

        // Task DownloadResume();
    }
}
