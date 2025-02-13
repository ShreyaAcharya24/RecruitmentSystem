using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddInterviewRound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewRoundMasters",
                columns: table => new
                {
                    RoundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
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
                    RoundID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    DriveID = table.Column<int>(type: "int", nullable: true),
                    SequenceOrder = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    InterviewRoundMasterRoundID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRounds", x => x.InterviewRoundID);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewRounds");

            migrationBuilder.DropTable(
                name: "InterviewRoundMasters");
        }
    }
}
