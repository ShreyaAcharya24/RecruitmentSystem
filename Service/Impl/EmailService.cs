using RecruitmentSystem.Repository;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service.Impl
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly ICandidateRepository _candidateRepository;

        private readonly IApplicationRepository _applicationRepositry;

        public EmailService(IEmailSender emailSender, ICandidateRepository candidateRepository,IApplicationRepository applicationRepository)
        {
            _emailSender = emailSender;
            _candidateRepository = candidateRepository;
            _applicationRepositry =applicationRepository;
        }

        public async Task SendDocumentUploadEmail(int candidateId, int applicationId)
        {
            var candidate = await _candidateRepository.GetCandidateById(candidateId);
            var application = await _applicationRepositry.GetApplicationById(applicationId);
            if (candidate == null) return;

            string subject = "Document Upload Request";
            string body = $"<html>" +
                          $"<body style='font-family: Arial, sans-serif;'>" +
                          $"<h2 style='color: #2E86C1;'>Dear {candidate.FirstName},</h2>" +
                          $"<p>Thank you for applying for the <strong>{application.Job.Position}</strong> position at Roima Intelligence. Your Profile has been shortlisted for the Technical Round!</p>" +
                          $"<p>To proceed with your application, we need to verify some documents. Please upload the following documents as a single PDF:</p>" +
                          $"<ul>" +
                          $"<li>Resume/CV</li>" +
                          $"<li>Educational Certificates</li>" +
                          $"<li>Work Experience Letters</li>" +
                          $"<li>Government-issued ID (e.g., Adhaar, Passport, Driver's License)</li>" +
                          $"</ul>" +
                          $"<p>You can upload these documents through our secure portal by clicking the link below:</p>" +
                          $"<p><a href='[Call Upload Doc API]' style='color: #2E86C1; text-decoration: none;'>Upload Documents</a></p>" +
                          $"<p>If you have any questions or need assistance, please do not hesitate to contact us at +91-9779977000.</p>" +
                          $"<p>Thank you for your cooperation.</p>" +
                          $"<p>Best regards,</p>" +
                          $"<p><strong>Shreya Acharya</strong><br>" +
                          $"Sr. HR Manager<br>" +
                          $"Roima Intelligence India<br>" +
                          $"+911111111111</p>" +
                          $"</body>" +
                          $"</html>";

            await _emailSender.SendEmailAsync(candidate.RUser.Email, subject, body);
        }
    }
}
