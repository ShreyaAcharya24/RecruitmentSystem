using Microsoft.AspNetCore.Http.HttpResults;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;

namespace RecruitmentSystem.Service.Impl
{
    public class VerificationService : IVerificationService
    {
        private readonly IVerificationRepository _repository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IConfiguration _configuration;

        public VerificationService(IVerificationRepository repository, IConfiguration configuration, IApplicationRepository applicationRepository)
        {
            _repository = repository;
            _applicationRepository = applicationRepository;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Verification>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Verification> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddVerification(int applicationId)
        {
            var verification = new Verification
            {
                ApplicationID = applicationId,
                Status = VerificationStatus.InProgress,
                DocumentPath = null,
                Remarks = null,
                VerifierID = null
            };

            await _repository.AddAsync(verification);
        }

        public async Task<bool> UpdateVerificationStatus(int verificationId, UpdateVerificationDTO dto)
        {
            var verification = await _repository.GetByIdAsync(verificationId);
            if (verification == null) return false;

            verification.Status = dto.Status;
            verification.Remarks = dto.Remarks;
            verification.VerifierID = dto.VerifierID;

            await _repository.UpdateAsync(verification);

            // Update ApplicationStatus Based on VerificationStatus
            var application = await _applicationRepository.GetApplicationById(verification.ApplicationID);
            application.Status = ApplicationStatus.UnderReview;
            if (application != null)
            {
                if (dto.Status == VerificationStatus.Successful)
                {
                    application.Status = ApplicationStatus.Verified;
                    application.Comments = "Documents Verified";
                }
                else if (dto.Status == VerificationStatus.Failed)
                {
                    application.Status = ApplicationStatus.Unverified;
                    application.Comments = "Physical Documents Verification needed";
                }

                await _applicationRepository.UpdateApplicationStatus(application.ApplicationID,application.Status);
            }

            return true;
        }

         public async Task<string> GetVerificationDocumentPath(int verificationId)
        {
            var verification = await _repository.GetByIdAsync(verificationId);
            if (verification == null || string.IsNullOrEmpty(verification.DocumentPath))
                throw new FileNotFoundException("No document found for this verification.");

            return verification.DocumentPath;
        }
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<string> UploadDocument(int applicationId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new InvalidOperationException("Invalid file size or type. Please upload a valid PDF.");

            var allowedExtensions = new[] { ".pdf" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
                throw new InvalidOperationException("Only PDF files are allowed.");

            var verification = await _repository.GetByApplicationIDAsync(applicationId);
            if (verification == null)
                throw new InvalidOperationException("Verification record not found for this application.");

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "VerificationUploads");

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var currentDateTime = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            string filePath = Path.Combine(uploadFolder, $"{verification.ApplicationID}_Verification_{currentDateTime}{fileExtension}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            verification.DocumentPath = filePath;
            await _repository.UpdateAsync(verification);

            return "Document uploaded successfully.";
        }
    }

}
