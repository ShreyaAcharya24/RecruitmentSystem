using RecruitmentSystem.Repository;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IVerificationService _verificationService;
        private readonly IEmailService _emailService;

        public ApplicationService(
            IApplicationRepository applicationRepository, 
            IVerificationService verificationService,
            IEmailService emailService)
        {
            _applicationRepository = applicationRepository;
            _verificationService = verificationService;
            _emailService = emailService;
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
            // var application = await _applicationRepository.GetApplicationById(applicationId);
            // if (application == null) return false;

            bool statusUpdated = await _applicationRepository.UpdateApplicationStatus(applicationId, status);
            if (!statusUpdated) return false;

            // If the application is shortlisted, trigger Verification & Send Email
            if (status == ApplicationStatus.Shortlisted)
            {
                var application = await _applicationRepository.GetApplicationById(applicationId);
                await _verificationService.AddVerification(application.ApplicationID);
                await _emailService.SendDocumentUploadEmail(application.CandidateID, application.ApplicationID);
            }

            return true;
        }

        public async Task<bool> AssignReviewerToApplication(int applicationId, int reviewerId)
        {
            return await _applicationRepository.AssignReviewerToApplication(applicationId, reviewerId);
        }
    }
}
