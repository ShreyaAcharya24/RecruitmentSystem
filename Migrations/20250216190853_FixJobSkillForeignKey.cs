using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixJobSkillForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobID",
                table: "JobSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobID1",
                table: "JobSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobSkills_JobID1",
                table: "JobSkills");

            migrationBuilder.DropColumn(
                name: "JobID1",
                table: "JobSkills");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobID",
                table: "JobSkills",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobID",
                table: "JobSkills");

            migrationBuilder.AddColumn<int>(
                name: "JobID1",
                table: "JobSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobID1",
                table: "JobSkills",
                column: "JobID1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobID",
                table: "JobSkills",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobID1",
                table: "JobSkills",
                column: "JobID1",
                principalTable: "Jobs",
                principalColumn: "JobID");
        }
    }
}
