using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RacooterCarTradingApp.Data.Migrations
{
    public partial class announcementTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementId);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApprovedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.HistoryId);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementImages",
                columns: table => new
                {
                    AnnouncementImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementImages", x => x.AnnouncementImageId);
                    table.ForeignKey(
                        name: "FK_AnnouncementImages_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "AnnouncementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    SpecificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetFuelType = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrOfDoors = table.Column<int>(type: "int", nullable: false),
                    GearBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNegotiable = table.Column<bool>(type: "bit", nullable: false),
                    IsFullOptions = table.Column<bool>(type: "bit", nullable: false),
                    HasABS = table.Column<bool>(type: "bit", nullable: false),
                    HasESP = table.Column<bool>(type: "bit", nullable: false),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: false),
                    HasLogHistory = table.Column<bool>(type: "bit", nullable: false),
                    HasCruiseControl = table.Column<bool>(type: "bit", nullable: false),
                    HasDualZoneClimate = table.Column<bool>(type: "bit", nullable: false),
                    HasFullElectricWin = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedSeats = table.Column<bool>(type: "bit", nullable: false),
                    HasVentedSeats = table.Column<bool>(type: "bit", nullable: false),
                    HasElectricMirrors = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedStWheel = table.Column<bool>(type: "bit", nullable: false),
                    HadAccident = table.Column<bool>(type: "bit", nullable: false),
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.SpecificationId);
                    table.ForeignKey(
                        name: "FK_Specifications_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "AnnouncementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementHistoryImages",
                columns: table => new
                {
                    AnnouncementHistoryImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementHistoryImages", x => x.AnnouncementHistoryImageId);
                    table.ForeignKey(
                        name: "FK_AnnouncementHistoryImages_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "HistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationHistories",
                columns: table => new
                {
                    SpecificationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetFuelType = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrOfDoors = table.Column<int>(type: "int", nullable: false),
                    GearBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNegotiable = table.Column<bool>(type: "bit", nullable: false),
                    IsFullOptions = table.Column<bool>(type: "bit", nullable: false),
                    HasABS = table.Column<bool>(type: "bit", nullable: false),
                    HasESP = table.Column<bool>(type: "bit", nullable: false),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: false),
                    HasLogHistory = table.Column<bool>(type: "bit", nullable: false),
                    HasCruiseControl = table.Column<bool>(type: "bit", nullable: false),
                    HasDualZoneClimate = table.Column<bool>(type: "bit", nullable: false),
                    HasFullElectricWin = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedSeats = table.Column<bool>(type: "bit", nullable: false),
                    HasVentedSeats = table.Column<bool>(type: "bit", nullable: false),
                    HasElectricMirrors = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedStWheel = table.Column<bool>(type: "bit", nullable: false),
                    HadAccident = table.Column<bool>(type: "bit", nullable: false),
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationHistories", x => x.SpecificationHistoryId);
                    table.ForeignKey(
                        name: "FK_SpecificationHistories_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "HistoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementHistoryImages_HistoryId",
                table: "AnnouncementHistoryImages",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementImages_AnnouncementId",
                table: "AnnouncementImages",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationHistories_HistoryId",
                table: "SpecificationHistories",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_AnnouncementId",
                table: "Specifications",
                column: "AnnouncementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementHistoryImages");

            migrationBuilder.DropTable(
                name: "AnnouncementImages");

            migrationBuilder.DropTable(
                name: "SpecificationHistories");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Announcements");
        }
    }
}
