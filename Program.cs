using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Config;
using RecruitmentSystem.Data;
using RecruitmentSystem.Middleware;
using RecruitmentSystem.Models;
using RecruitmentSystem.Repository;
using RecruitmentSystem.Repository.Impl;
using RecruitmentSystem.Service;
using RecruitmentSystem.Service.Impl;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService,CandidateService>();
builder.Services.AddScoped<ISkillCategoryRepository, SkillCategoryRepository>();
builder.Services.AddScoped<ISkillCategoryService, SkillCategoryService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobSkillRepository, JobSkillRepository>();
builder.Services.AddScoped<IJobSkillService, JobSkillService>();
builder.Services.AddScoped<IEmployeeSkillRepository, EmployeeSkillRepository>();
builder.Services.AddScoped<IEmployeeSkillService, EmployeeSkillService>();
builder.Services.AddScoped<ICandidateSkillRepository, CandidateSkillRepository>();
builder.Services.AddScoped<ICandidateSkillService, CandidateSkillService>();
builder.Services.AddScoped<IJobReviewerRepository, JobReviewerRepository>();
builder.Services.AddScoped<IJobReviewerService, JobReviwerService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailSender, EmailSender>(); 
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>(); 
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IHiringDriveRepository, HiringDriveRepository>();
builder.Services.AddScoped<IHiringDriveService, HiringDriveService>();
builder.Services.AddScoped<IRoundMasterRepository, RoundMasterRepository>();
builder.Services.AddScoped<IRoundMasterService, RoundMasterService>();
builder.Services.AddScoped<IInterviewRoundRepository, InterviewRoundRepository>();
builder.Services.AddScoped<IInterviewRoundService, InterviewRoundService>();
builder.Services.AddScoped<IPanelRepository, PanelRepository>();
builder.Services.AddScoped<IPanelService, PanelService>();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IVerificationRepository, VerificationRepository>();
builder.Services.AddScoped<IVerificationService, VerificationService>();
builder.Services.AddScoped<ICandidateSkillRatingRepository, CandidateSkillRatingRepository>();
builder.Services.AddScoped<ICandidateSkillRatingService, CandidateSkillRatingService>();
builder.Services.AddScoped<CandidateService>();
builder.Services.AddScoped<CandidateExcelService>();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10485760; // 10MB limit
});

AppDomain.CurrentDomain.ProcessExit += (s, e) =>
{
    Console.WriteLine("Application is shutting down...");
};

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();
