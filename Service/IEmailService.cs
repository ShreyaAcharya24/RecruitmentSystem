namespace RecruitmentSystem.Service
{
    public interface IEmailService
    {
        Task SendDocumentUploadEmail(int candidateId, int applicationId);
    }
}
