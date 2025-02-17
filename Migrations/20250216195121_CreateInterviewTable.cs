using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateInterviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    InterviewRoundID = table.Column<int>(type: "int", nullable: false),
                    PanelID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InterviewFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewID);
                    table.ForeignKey(
                        name: "FK_Interviews_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_InterviewRounds_InterviewRoundID",
                        column: x => x.InterviewRoundID,
                        principalTable: "InterviewRounds",
                        principalColumn: "InterviewRoundID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_Panels_PanelID",
                        column: x => x.PanelID,
                        principalTable: "Panels",
                        principalColumn: "PanelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicationID",
                table: "Interviews",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewRoundID",
                table: "Interviews",
                column: "InterviewRoundID");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_PanelID",
                table: "Interviews",
                column: "PanelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interviews");
        }
    }
}
