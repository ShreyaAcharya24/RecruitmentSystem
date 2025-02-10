using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUserRepository _userRepository;

        public CandidateService(ICandidateRepository candidateRepository, IUserRepository userRepository)
        {
            _candidateRepository = candidateRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            return await _candidateRepository.GetAllCandidates();
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _candidateRepository.GetCandidateById(id);
        }

        public async Task<Candidate> AddCandidate(Candidate candidate)
        {

            if (string.IsNullOrWhiteSpace(candidate.RUser.Email) || string.IsNullOrWhiteSpace(candidate.RUser.Password))
            {
                throw new ArgumentException("Email and Password are required.");
            }

            // Check if email already exists
            var existingUser = await _userRepository.GetUserByEmail(candidate.RUser.Email);
            if (existingUser != null)
            {
                throw new InvalidDataException("Email already in use");
            }

            // Hash password before saving
            candidate.RUser.Password = BCrypt.Net.BCrypt.HashPassword(candidate.RUser.Password);
            candidate.RUser.Role = UserRole.Candidate;

            // Save user first
            var newUser = await _userRepository.AddUser(candidate.RUser);
            candidate.RUserID = newUser.RUserID;
            // candidate.RUser = null;

            // Save candidate
            return await _candidateRepository.AddCandidate(candidate);
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            return await _candidateRepository.UpdateCandidate(candidate);
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            return await _candidateRepository.DeleteCandidate(id);
        }

         public async Task<bool> DoesCandidateExistAsync(int id)
        {
            return await _candidateRepository.CandidateExistsAsync(id);
        }
    }
}
