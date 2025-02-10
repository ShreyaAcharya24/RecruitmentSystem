using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeleteForCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidates_RUserID",
                table: "Candidates");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_RUserID",
                table: "Candidates",
                column: "RUserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidates_RUserID",
                table: "Candidates");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_RUserID",
                table: "Candidates",
                column: "RUserID");
        }
    }
}
