using Microsoft.EntityFrameworkCore.Migrations;

namespace RacooterCarTradingApp.Data.Migrations
{
    public partial class mig77 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Announcements");
        }
    }
}
