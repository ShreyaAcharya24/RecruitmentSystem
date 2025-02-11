using RecruitmentSystem.Repository;
using RecruitmentSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<Application> SubmitApplication(Application application)
        {
            return await _applicationRepository.SubmitApplication(application);
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            return await _applicationRepository.GetAllApplications();
        }

        public async Task<Application> GetApplicationById(int id)
        {
            return await _applicationRepository.GetApplicationById(id);
        }

        public async Task<IEnumerable<Application>> GetApplicationsByCandidate(int candidateId)
        {
            return await _applicationRepository.GetApplicationsByCandidate(candidateId);
        }

        public async Task<bool> UpdateApplicationStatus(int applicationId, ApplicationStatus status)
        {
            return await _applicationRepository.UpdateApplicationStatus(applicationId, status);
        }

        public async Task<bool> AssignReviewerToApplication(int applicationId, int reviewerId)
        {
            return await _applicationRepository.AssignReviewerToApplication(applicationId, reviewerId);
        }
    }
}
