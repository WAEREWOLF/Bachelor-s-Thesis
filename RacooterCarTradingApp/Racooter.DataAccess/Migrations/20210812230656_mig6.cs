using Microsoft.EntityFrameworkCore.Migrations;

namespace RacooterCarTradingApp.Data.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerInfoId",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_SellerInfoId",
                table: "Announcements",
                column: "SellerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_SellerInfoId",
                table: "Announcements",
                column: "SellerInfoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_SellerInfoId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_SellerInfoId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "SellerInfoId",
                table: "Announcements");
        }
    }
}
