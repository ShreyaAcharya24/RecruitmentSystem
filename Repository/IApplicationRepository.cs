using RecruitmentSystem.Models;

namespace RecruitmentSystem.Repository
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllApplications();
        Task<Application> GetApplicationById(int id);

        // Status, Comments and Reviewer ID should be Hidden from candidate 
        Task<Application> AddApplication(Application application);

        // Allow only specific fields to update
        Task<Application> UpdateApplication(Application application);
        Task<bool> DeleteApplication(int id);

        // Filter Applications using ApplicationStatus
        Task<IEnumerable<Application>> GetApplicationsByStatus(string status);
    }
}
