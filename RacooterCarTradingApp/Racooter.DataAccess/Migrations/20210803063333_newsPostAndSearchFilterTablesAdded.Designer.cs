﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Racooter.DataAccess.DbContext;

namespace RacooterCarTradingApp.Data.Migrations
{
    [DbContext(typeof(RacooterDbContext))]
    [Migration("20210803063333_newsPostAndSearchFilterTablesAdded")]
    partial class newsPostAndSearchFilterTablesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.Announcement", b =>
                {
                    b.Property<Guid>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApprovedByAdmin")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("AnnouncementId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.AnnouncementHistoryImage", b =>
                {
                    b.Property<Guid>("AnnouncementHistoryImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnnouncementHistoryImageId");

                    b.HasIndex("HistoryId");

                    b.ToTable("AnnouncementHistoryImages");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.AnnouncementImage", b =>
                {
                    b.Property<Guid>("AnnouncementImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnnouncementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnnouncementImageId");

                    b.HasIndex("AnnouncementId");

                    b.ToTable("AnnouncementImages");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsBlockFromPost")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsReportedForBlock")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ReportedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.History", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnnouncementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApprovedByAdmin")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("HistoryId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.NewsPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewsPosts");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.SearchFilter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Make")
                        .HasColumnType("int");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<int?>("Model")
                        .HasColumnType("int");

                    b.Property<int?>("Power")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SearchFilters");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.Specification", b =>
                {
                    b.Property<Guid>("SpecificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnnouncementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearBox")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GetFuelType")
                        .HasColumnType("int");

                    b.Property<bool>("HadAccident")
                        .HasColumnType("bit");

                    b.Property<bool>("HasABS")
                        .HasColumnType("bit");

                    b.Property<bool>("HasCruiseControl")
                        .HasColumnType("bit");

                    b.Property<bool>("HasDualZoneClimate")
                        .HasColumnType("bit");

                    b.Property<bool>("HasESP")
                        .HasColumnType("bit");

                    b.Property<bool>("HasElectricMirrors")
                        .HasColumnType("bit");

                    b.Property<bool>("HasFullElectricWin")
                        .HasColumnType("bit");

                    b.Property<bool>("HasHeatedSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("HasHeatedStWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("HasLogHistory")
                        .HasColumnType("bit");

                    b.Property<bool>("HasVentedSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWarranty")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFullOptions")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNegotiable")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<int?>("Model")
                        .HasColumnType("int");

                    b.Property<int?>("NrOfDoors")
                        .HasColumnType("int");

                    b.Property<int?>("Power")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("SpecificationId");

                    b.HasIndex("AnnouncementId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.SpecificationHistory", b =>
                {
                    b.Property<Guid>("SpecificationHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnnouncementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearBox")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GetFuelType")
                        .HasColumnType("int");

                    b.Property<bool>("HadAccident")
                        .HasColumnType("bit");

                    b.Property<bool>("HasABS")
                        .HasColumnType("bit");

                    b.Property<bool>("HasCruiseControl")
                        .HasColumnType("bit");

                    b.Property<bool>("HasDualZoneClimate")
                        .HasColumnType("bit");

                    b.Property<bool>("HasESP")
                        .HasColumnType("bit");

                    b.Property<bool>("HasElectricMirrors")
                        .HasColumnType("bit");

                    b.Property<bool>("HasFullElectricWin")
                        .HasColumnType("bit");

                    b.Property<bool>("HasHeatedSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("HasHeatedStWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("HasLogHistory")
                        .HasColumnType("bit");

                    b.Property<bool>("HasVentedSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWarranty")
                        .HasColumnType("bit");

                    b.Property<Guid?>("HistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFullOptions")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNegotiable")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mileage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfDoors")
                        .HasColumnType("int");

                    b.Property<string>("Power")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecificationHistoryId");

                    b.HasIndex("HistoryId");

                    b.ToTable("SpecificationHistories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Racooter.DataAccess.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.AnnouncementHistoryImage", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.History", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId");

                    b.Navigation("History");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.AnnouncementImage", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.Announcement", "Announcement")
                        .WithMany()
                        .HasForeignKey("AnnouncementId");

                    b.Navigation("Announcement");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.Specification", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.Announcement", "Announcement")
                        .WithMany()
                        .HasForeignKey("AnnouncementId");

                    b.Navigation("Announcement");
                });

            modelBuilder.Entity("Racooter.DataAccess.Models.SpecificationHistory", b =>
                {
                    b.HasOne("Racooter.DataAccess.Models.History", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId");

                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
