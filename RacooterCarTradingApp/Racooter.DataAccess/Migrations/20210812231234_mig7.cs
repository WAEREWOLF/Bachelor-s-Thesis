using Microsoft.EntityFrameworkCore.Migrations;

namespace RacooterCarTradingApp.Data.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Announcements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
