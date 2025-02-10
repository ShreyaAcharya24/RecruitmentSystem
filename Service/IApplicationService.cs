using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IApplicationService
    {
         Task<IEnumerable<Application>> GetAllApplications();
        Task<Application> GetApplicationById(int id);

        Task<Application> AddApplication(Application application);

        Task<Application> UpdateApplication(Application application);
        Task<bool> DeleteApplication(int id);

        Task<IEnumerable<Application>> GetApplicationsByStatus(string status);
    }
}
