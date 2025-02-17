using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Service
{
    public interface IApplicationService
    {
        Task<Application> SubmitApplication(Application application);
        Task<IEnumerable<Application>> GetAllApplications();
        Task<Application> GetApplicationById(int id);
        Task<IEnumerable<Application>> GetApplicationsByCandidate(int candidateId);
        Task<bool> UpdateApplicationStatus(int applicationId, ApplicationStatus status);
        Task<bool> AssignReviewerToApplication(int applicationId, int reviewerId);


    }
}