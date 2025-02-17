using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateRoundMasterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_HiringDrives_DriveID",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "RoundMasters",
                columns: table => new
                {
                    RoundMasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoundName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundMasters", x => x.RoundMasterID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_HiringDrives_DriveID",
                table: "Jobs",
                column: "DriveID",
                principalTable: "HiringDrives",
                principalColumn: "DriveID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_HiringDrives_DriveID",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "RoundMasters");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_HiringDrives_DriveID",
                table: "Jobs",
                column: "DriveID",
                principalTable: "HiringDrives",
                principalColumn: "DriveID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
