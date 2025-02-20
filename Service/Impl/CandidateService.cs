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
            var candidate = await _candidateRepository.GetCandidateById(id);
            if (candidate == null)
            {
                throw new KeyNotFoundException($"Candidate with {id} not found");
            }
            return candidate;
        }

        public async Task<Candidate> AddCandidate(Candidate candidate, IFormFile resumeFile)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate), "Candidate details cannot be null.");
            }
            // **** Write validations and remove this from here
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

            // Handle resume upload
            if (resumeFile != null && resumeFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var currentDateTime = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                var uniqueFileName = candidate.RUserID.ToString() + "_CV_" + currentDateTime + Path.GetExtension(resumeFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await resumeFile.CopyToAsync(fileStream);
                }

                candidate.Resume = filePath;
            }

            // Save Candidate
            return await _candidateRepository.AddCandidate(candidate);
        }
        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            if (candidate == null || candidate.CandidateID == 0)
            {
                throw new ArgumentException("Invalid Candidate data.");
            }

            var existingCandidate = await _candidateRepository.GetCandidateById(candidate.CandidateID);
            if (existingCandidate == null)
            {
                throw new KeyNotFoundException($"Candidate with ID {candidate.CandidateID} not found.");
            }

            return await _candidateRepository.UpdateCandidate(candidate);

        }

        public async Task<bool> DeleteCandidate(int id)
        {

            var isDeleted = await _candidateRepository.DeleteCandidate(id);
            if (isDeleted == false)
            {
                throw new KeyNotFoundException($"Candidate with ID {id} not found.");
            }
            return await _candidateRepository.DeleteCandidate(id);
        }

        public async Task<bool> DoesCandidateExistAsync(int id)
        {
            return await _candidateRepository.CandidateExistsAsync(id);
        }
    }
}
