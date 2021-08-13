using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RacooterCarTradingApp.Data.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificationHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificationHistories",
                columns: table => new
                {
                    SpecificationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GearBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetFuelType = table.Column<int>(type: "int", nullable: false),
                    HadAccident = table.Column<bool>(type: "bit", nullable: false),
                    HasABS = table.Column<bool>(type: "bit", nullable: false),
                    HasCruiseControl = table.Column<bool>(type: "bit", nullable: false),
                    HasDualZoneClimate = table.Column<bool>(type: "bit", nullable: false),
                    HasESP = table.Column<bool>(type: "bit", nullable: false),
                    HasElectricMirrors = table.Column<bool>(type: "bit", nullable: false),
                    HasFullElectricWin = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedSeats = table.Column<bool>(type: "bit", nullable: false),
                    HasHeatedStWheel = table.Column<bool>(type: "bit", nullable: false),
                    HasLogHistory = table.Column<bool>(type: "bit", nullable: false),
                    HasVentedSeats = table.Column<bool>(type: "bit", nullable: false),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: false),
                    HistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsFullOptions = table.Column<bool>(type: "bit", nullable: false),
                    IsNegotiable = table.Column<bool>(type: "bit", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrOfDoors = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_SpecificationHistories_HistoryId",
                table: "SpecificationHistories",
                column: "HistoryId");
        }
    }
}
