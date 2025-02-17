using RecruitmentSystem.DTOs;
using RecruitmentSystem.Enums;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IVerificationService
    {
        Task<IEnumerable<Verification>> GetAllAsync();
        Task<Verification> GetByIdAsync(int id);
        Task AddVerification(int applicationId);
        Task DeleteAsync(int id);
        Task<string> UploadDocument(int applicationId, IFormFile file);
        Task<string> GetVerificationDocumentPath(int verificationId);
        Task<bool> UpdateVerificationStatus(int verificationId, UpdateVerificationDTO dto);


    }
}
