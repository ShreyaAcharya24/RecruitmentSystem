using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IApplicationRepository
    {
        Task<Application> SubmitApplication(Application application);
        Task<IEnumerable<Application>> GetAllApplications();
        Task<Application> GetApplicationById(int id);
        Task<IEnumerable<Application>> GetApplicationsByCandidate(int candidateId);
        Task<bool> UpdateApplicationStatus(int applicationId, ApplicationStatus status);
        Task<bool> UpdateApplication(Application application);
        Task<bool> AssignReviewerToApplication(int applicationId, int reviewerId);

    }
}