using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class DeletedInterview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewRounds");

            migrationBuilder.DropTable(
                name: "InterviewRoundMasters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewRoundMasters",
                columns: table => new
                {
                    RoundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    RoundName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRoundMasters", x => x.RoundID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewRounds",
                columns: table => new
                {
                    InterviewRoundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveID = table.Column<int>(type: "int", nullable: true),
                    InterviewerID = table.Column<int>(type: "int", nullable: true),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    RoundID = table.Column<int>(type: "int", nullable: false),
                    InterviewRoundMasterRoundID = table.Column<int>(type: "int", nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    SequenceOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRounds", x => x.InterviewRoundID);
                    table.ForeignKey(
                        name: "FK_InterviewRounds_Employees_InterviewerID",
                        column: x => x.InterviewerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_InterviewRounds_HiringDrives_DriveID",
                        column: x => x.DriveID,
                        principalTable: "HiringDrives",
                        principalColumn: "DriveID");
                    table.ForeignKey(
                        name: "FK_InterviewRounds_InterviewRoundMasters_InterviewRoundMasterRoundID",
                        column: x => x.InterviewRoundMasterRoundID,
                        principalTable: "InterviewRoundMasters",
                        principalColumn: "RoundID");
                    table.ForeignKey(
                        name: "FK_InterviewRounds_InterviewRoundMasters_RoundID",
                        column: x => x.RoundID,
                        principalTable: "InterviewRoundMasters",
                        principalColumn: "RoundID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewRounds_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRounds_DriveID",
                table: "InterviewRounds",
                column: "DriveID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRounds_InterviewerID",
                table: "InterviewRounds",
                column: "InterviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRounds_InterviewRoundMasterRoundID",
                table: "InterviewRounds",
                column: "InterviewRoundMasterRoundID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRounds_JobID",
                table: "InterviewRounds",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRounds_RoundID",
                table: "InterviewRounds",
                column: "RoundID");
        }
    }
}
