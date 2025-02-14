using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Data;
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
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IHiringDriveRepository, HiringDriveRepository>();
builder.Services.AddScoped<IHiringDriveService, HiringDriveService>();
builder.Services.AddScoped<IInterviewRoundMasterRepository, InterviewRoundMasterRepository>();
builder.Services.AddScoped<IInterviewRoundMasterService, InterviewRoundMasterService>();
builder.Services.AddScoped<IInterviewRoundRepository, InterviewRoundRepository>();
builder.Services.AddScoped<IInterviewRoundService, InterviewRoundService>();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10485760; // 10MB limit
});

AppDomain.CurrentDomain.ProcessExit += (s, e) =>
{
    Console.WriteLine("Application is shutting down...");
};

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
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
app.UseAuthorization();
app.MapControllers();

app.Run();
