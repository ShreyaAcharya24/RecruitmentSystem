using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Service;

namespace RecruitmentSystem.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<Application>> GetAllApplications() => await _applicationRepository.GetAllApplications();

        public async Task<Application> GetApplicationById(int id) => await _applicationRepository.GetApplicationById(id);

        public async Task<Application> AddApplication(Application application) => await _applicationRepository.AddApplication(application);

        public async Task<Application> UpdateApplication(Application job) => await _applicationRepository.UpdateApplication(job);

        public async Task<bool> DeleteApplication(int id) => await _applicationRepository.DeleteApplication(id);

        Task<IEnumerable<Application>> IApplicationService.GetApplicationsByStatus(string status)
        {
            throw new NotImplementedException();
        }

        // public async Task<IEnumerable<Application>> GetOpe() => await _applicationRepository.GetOpenJobs();

    }
}
