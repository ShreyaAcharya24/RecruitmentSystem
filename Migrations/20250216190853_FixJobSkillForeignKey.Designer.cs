﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentSystem.Data;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250216190853_FixJobSkillForeignKey")]
    partial class FixJobSkillForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecruitmentSystem.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationID"));

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("JobID");

                    b.HasIndex("ReviewerID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Candidate", b =>
                {
                    b.Property<int>("CandidateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateID"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HighestQualification")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RUserID")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SchoolOrUniversity")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("ScoreGPA")
                        .HasColumnType("float");

                    b.Property<int>("TotalExperience")
                        .HasColumnType("int");

                    b.HasKey("CandidateID");

                    b.HasIndex("RUserID")
                        .IsUnique();

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.CandidateSkill", b =>
                {
                    b.Property<int>("CandidateSkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateSkillID"));

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.HasKey("CandidateSkillID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("SkillID");

                    b.ToTable("CandidateSkills");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RUserID")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("RUserID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeSkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeSkillID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeSkillID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("SkillID");

                    b.ToTable("EmployeeSkills");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.HiringDrive", b =>
                {
                    b.Property<int>("DriveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriveID"));

                    b.Property<string>("DriveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("DriveID");

                    b.ToTable("HiringDrives");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.InterviewRound", b =>
                {
                    b.Property<int>("InterviewRoundID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterviewRoundID"));

                    b.Property<bool>("IsFinalRound")
                        .HasColumnType("bit");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("RoundMasterID")
                        .HasColumnType("int");

                    b.Property<int>("SequenceOrder")
                        .HasColumnType("int");

                    b.HasKey("InterviewRoundID");

                    b.HasIndex("JobID");

                    b.HasIndex("RoundMasterID");

                    b.ToTable("InterviewRounds");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriveID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NoOfPositions")
                        .HasColumnType("int");

                    b.Property<string>("OtherCriteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PostedBy")
                        .HasColumnType("int");

                    b.Property<string>("PreferredSkills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredExperience")
                        .HasColumnType("int");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusReason")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("JobID");

                    b.HasIndex("DriveID");

                    b.HasIndex("PostedBy");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.JobReviwer", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerID")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("JobID");

                    b.HasIndex("ReviewerID");

                    b.ToTable("JobReviwers");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.JobSkill", b =>
                {
                    b.Property<int>("JobSkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobSkillID"));

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.HasKey("JobSkillID");

                    b.HasIndex("JobID");

                    b.HasIndex("SkillID");

                    b.ToTable("JobSkills");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Panel", b =>
                {
                    b.Property<int>("PanelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PanelID"));

                    b.Property<int>("InterviewRoundID")
                        .HasColumnType("int");

                    b.Property<int>("InterviewerID")
                        .HasColumnType("int");

                    b.HasKey("PanelID");

                    b.HasIndex("InterviewRoundID");

                    b.HasIndex("InterviewerID");

                    b.ToTable("Panels");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.RUser", b =>
                {
                    b.Property<int>("RUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RUserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RUserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.RoundMaster", b =>
                {
                    b.Property<int>("RoundMasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoundMasterID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("RoundName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoundMasterID");

                    b.ToTable("RoundMasters");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SkillID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.SkillCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryID");

                    b.ToTable("SkillCategories");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Application", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Employee", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Candidate");

                    b.Navigation("Job");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Candidate", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.RUser", "RUser")
                        .WithOne()
                        .HasForeignKey("RecruitmentSystem.Models.Candidate", "RUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RUser");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.CandidateSkill", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Employee", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.RUser", "RUser")
                        .WithMany()
                        .HasForeignKey("RUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("RUser");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.EmployeeSkill", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.InterviewRound", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.RoundMaster", "RoundMaster")
                        .WithMany()
                        .HasForeignKey("RoundMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("RoundMaster");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Job", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.HiringDrive", "HiringDrive")
                        .WithMany()
                        .HasForeignKey("DriveID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("PostedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("HiringDrive");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.JobReviwer", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Employee", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.JobSkill", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.Job", "Job")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Panel", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.InterviewRound", "InterviewRound")
                        .WithMany()
                        .HasForeignKey("InterviewRoundID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentSystem.Models.Employee", "Interviewer")
                        .WithMany()
                        .HasForeignKey("InterviewerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterviewRound");

                    b.Navigation("Interviewer");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Skill", b =>
                {
                    b.HasOne("RecruitmentSystem.Models.SkillCategory", "SkillCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SkillCategory");
                });

            modelBuilder.Entity("RecruitmentSystem.Models.Job", b =>
                {
                    b.Navigation("JobSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
