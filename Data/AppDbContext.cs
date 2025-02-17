using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RUser> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<JobReviwer> JobReviwers { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<HiringDrive> HiringDrives { get; set; }
        public DbSet<RoundMaster> RoundMasters { get; set; }
        public DbSet<InterviewRound> InterviewRounds { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Verification> Verifications { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.RUser)
                .WithMany()
                .HasForeignKey(e => e.RUserID);

            modelBuilder.Entity<Candidate>()
            .HasOne(c => c.RUser)
            .WithOne()
            .HasForeignKey<Candidate>(c => c.RUserID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skill>()
                .HasOne(s => s.SkillCategory)
                .WithMany() // No navigation property in SkillCategory
                .HasForeignKey(s => s.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Job and Employee who Posted the job
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Employee)
                .WithMany()
                .HasForeignKey(j => j.PostedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Job and HiringDrive
            modelBuilder.Entity<Job>()
            .HasOne(j => j.HiringDrive)
            .WithMany()
            .HasForeignKey(j => j.DriveID)
            .OnDelete(DeleteBehavior.NoAction);


            // Relationship: Job → JobSkills (One job can have multiple skills)
            modelBuilder.Entity<Job>()
            .HasMany(j => j.JobSkills)
            .WithOne(js => js.Job)
            .HasForeignKey(js => js.JobID)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Job)
                .WithMany(j => j.JobSkills)
                .HasForeignKey(js => js.JobID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobSkill>()
                .HasOne(js => js.Skill)
                .WithMany()
                .HasForeignKey(js => js.SkillID)
                .OnDelete(DeleteBehavior.Cascade);


            // Relationship between EmployeeSkill and Employee
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Employee)
                .WithMany()
                .HasForeignKey(es => es.EmployeeID)
                .OnDelete(DeleteBehavior.NoAction);


            // Relationship between EmployeeSkill and Skill
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Skill)
                .WithMany()
                .HasForeignKey(es => es.SkillID)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship between CandidateSkill and Candidate
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Candidate)
                .WithMany()
                .HasForeignKey(cs => cs.CandidateID)
                .OnDelete(DeleteBehavior.NoAction);


            // Relationship between CandidateSkill and Skill
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany()
                .HasForeignKey(cs => cs.SkillID)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship between JobReviewer and Reviewer(Employee) who's gonna review job applications
            modelBuilder.Entity<JobReviwer>()
            .HasOne(r => r.Reviewer)
            .WithMany()
            .HasForeignKey(r => r.ReviewerID)
            .OnDelete(DeleteBehavior.Cascade);

            // Relationship between JobReviewer and Job for which a reviewer has been assigned
            modelBuilder.Entity<JobReviwer>()
            .HasOne(j => j.Job)
            .WithMany()
            .HasForeignKey(j => j.JobID)
            .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Application and Job 
            modelBuilder.Entity<Application>()
            .HasOne(a => a.Job)
            .WithMany()
            .HasForeignKey(a => a.JobID)
            .OnDelete(DeleteBehavior.NoAction);

            // Relationship between Application and Candidate 
            modelBuilder.Entity<Application>()
            .HasOne(a => a.Candidate)
            .WithMany()
            .HasForeignKey(a => a.CandidateID)
            .OnDelete(DeleteBehavior.Cascade);

            // Relationship between Application and Reveiewer 
            modelBuilder.Entity<Application>()
            .HasOne(a => a.Reviewer)
            .WithMany()
            .HasForeignKey(a => a.ReviewerID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Interview>()
             .HasOne(i => i.Application)
             .WithMany()
             .HasForeignKey(i => i.ApplicationID); 


            // InterviewRound -> Interview (SET NULL)
            modelBuilder.Entity<Interview>()
                .HasOne(i => i.InterviewRound)
                .WithMany()
                .HasForeignKey(i => i.InterviewRoundID); // 🔹 Instead of Cascade, set to NULL

            // Panel -> Interview (SET NULL)
            modelBuilder.Entity<Interview>()
                .HasOne(i => i.Panel)
                .WithMany()
                .HasForeignKey(i => i.PanelID); // 🔹 Instead of Cascade, set to NUL




        }
    }
}
