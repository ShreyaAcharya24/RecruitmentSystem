using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangedJobReviewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobReviwers_Applications_JobID",
                table: "JobReviwers");

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviwers_Jobs_JobID",
                table: "JobReviwers",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobReviwers_Jobs_JobID",
                table: "JobReviwers");

            migrationBuilder.AddForeignKey(
                name: "FK_JobReviwers_Applications_JobID",
                table: "JobReviwers",
                column: "JobID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
