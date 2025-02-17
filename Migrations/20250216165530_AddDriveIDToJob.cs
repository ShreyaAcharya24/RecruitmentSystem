using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDriveIDToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriveID",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DriveID",
                table: "Jobs",
                column: "DriveID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_HiringDrives_DriveID",
                table: "Jobs",
                column: "DriveID",
                principalTable: "HiringDrives",
                principalColumn: "DriveID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_HiringDrives_DriveID",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_DriveID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DriveID",
                table: "Jobs");
        }
    }
}
