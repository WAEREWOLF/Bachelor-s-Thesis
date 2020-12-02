using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Racooter.DataAccess.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Block = table.Column<string>(nullable: true),
                    Coordinates = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    GetUserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Mileage = table.Column<string>(nullable: true),
                    GetFuelType = table.Column<int>(nullable: false),
                    Power = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    NrOfDoors = table.Column<int>(nullable: false),
                    GearBox = table.Column<string>(nullable: true),
                    EngineSize = table.Column<string>(nullable: true),
                    Emissions = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    IsNegotiable = table.Column<bool>(nullable: false),
                    IsFullOptions = table.Column<bool>(nullable: false),
                    HasABS = table.Column<bool>(nullable: false),
                    HasESP = table.Column<bool>(nullable: false),
                    HasWarranty = table.Column<bool>(nullable: false),
                    HasLogHistory = table.Column<bool>(nullable: false),
                    HasCruiseControl = table.Column<bool>(nullable: false),
                    HasDualZoneClimate = table.Column<bool>(nullable: false),
                    HasFullElectricWin = table.Column<bool>(nullable: false),
                    HasHeatedSeats = table.Column<bool>(nullable: false),
                    HasVentedSeats = table.Column<bool>(nullable: false),
                    HasElectricMirrors = table.Column<bool>(nullable: false),
                    HasHeatedStWheel = table.Column<bool>(nullable: false),
                    HadAccident = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticatedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonalDataId = table.Column<Guid>(nullable: true),
                    HistoryId = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    Credits = table.Column<decimal>(nullable: false),
                    NrOfAnnouncements = table.Column<int>(nullable: false),
                    UserType = table.Column<string>(nullable: true),
                    GetState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticatedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthenticatedUsers_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthenticatedUsers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthenticatedUsers_PersonalDatas_PersonalDataId",
                        column: x => x.PersonalDataId,
                        principalTable: "PersonalDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsBuy = table.Column<bool>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SpecificationId = table.Column<Guid>(nullable: true),
                    HistoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryItems_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoryItems_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthenticatedUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AuthenticatedUsers_AuthenticatedUserId",
                        column: x => x.AuthenticatedUserId,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SpecificationId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Views = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsAproved = table.Column<bool>(nullable: false),
                    AuthenticatedUserId = table.Column<Guid>(nullable: true),
                    AuthenticatedUserId1 = table.Column<Guid>(nullable: true),
                    AuthenticatedUserId2 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_AuthenticatedUsers_AuthenticatedUserId",
                        column: x => x.AuthenticatedUserId,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_AuthenticatedUsers_AuthenticatedUserId1",
                        column: x => x.AuthenticatedUserId1,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_AuthenticatedUsers_AuthenticatedUserId2",
                        column: x => x.AuthenticatedUserId2,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Announcements_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    RecipientId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AuthenticatedUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthenticatedUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moderators_AuthenticatedUsers_AuthenticatedUserId",
                        column: x => x.AuthenticatedUserId,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    AnnouncementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementImage_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false),
                    AdminId = table.Column<Guid>(nullable: true),
                    ModeratorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPosts_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsPosts_Moderators_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Moderators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AuthenticatedUserId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NewsPostId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AuthenticatedUsers_AuthenticatedUserId",
                        column: x => x.AuthenticatedUserId,
                        principalTable: "AuthenticatedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_NewsPosts_NewsPostId",
                        column: x => x.NewsPostId,
                        principalTable: "NewsPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AuthenticatedUserId",
                table: "Admins",
                column: "AuthenticatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementImage_AnnouncementId",
                table: "AnnouncementImage",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AuthenticatedUserId",
                table: "Announcements",
                column: "AuthenticatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AuthenticatedUserId1",
                table: "Announcements",
                column: "AuthenticatedUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AuthenticatedUserId2",
                table: "Announcements",
                column: "AuthenticatedUserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_SpecificationId",
                table: "Announcements",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticatedUsers_HistoryId",
                table: "AuthenticatedUsers",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticatedUsers_LocationId",
                table: "AuthenticatedUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticatedUsers_PersonalDataId",
                table: "AuthenticatedUsers",
                column: "PersonalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthenticatedUserId",
                table: "Comments",
                column: "AuthenticatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsPostId",
                table: "Comments",
                column: "NewsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryItems_HistoryId",
                table: "HistoryItems",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryItems_SpecificationId",
                table: "HistoryItems",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_AuthenticatedUserId",
                table: "Moderators",
                column: "AuthenticatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_AdminId",
                table: "NewsPosts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_ModeratorId",
                table: "NewsPosts",
                column: "ModeratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementImage");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "HistoryItems");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "NewsPosts");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropTable(
                name: "AuthenticatedUsers");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PersonalDatas");
        }
    }
}
