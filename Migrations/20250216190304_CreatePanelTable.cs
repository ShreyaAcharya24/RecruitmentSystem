using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreatePanelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Panels",
                columns: table => new
                {
                    PanelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewRoundID = table.Column<int>(type: "int", nullable: false),
                    InterviewerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panels", x => x.PanelID);
                    table.ForeignKey(
                        name: "FK_Panels_Employees_InterviewerID",
                        column: x => x.InterviewerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Panels_InterviewRounds_InterviewRoundID",
                        column: x => x.InterviewRoundID,
                        principalTable: "InterviewRounds",
                        principalColumn: "InterviewRoundID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Panels_InterviewerID",
                table: "Panels",
                column: "InterviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_Panels_InterviewRoundID",
                table: "Panels",
                column: "InterviewRoundID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Panels");
        }
    }
}
