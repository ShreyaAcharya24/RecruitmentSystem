using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidateSkillRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateSkillRatings",
                columns: table => new
                {
                    RateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    JobSkillID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkillRatings", x => x.RateID);
                    table.ForeignKey(
                        name: "FK_CandidateSkillRatings_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkillRatings_JobSkills_JobSkillID",
                        column: x => x.JobSkillID,
                        principalTable: "JobSkills",
                        principalColumn: "JobSkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillRatings_ApplicationID",
                table: "CandidateSkillRatings",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillRatings_JobSkillID",
                table: "CandidateSkillRatings",
                column: "JobSkillID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkillRatings");
        }
    }
}
