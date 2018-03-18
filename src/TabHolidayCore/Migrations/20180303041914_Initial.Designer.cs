using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TabHolidayCore.Models;

namespace TabHolidayCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180303041914_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TabHolidayCore.Models.Agency", b =>
                {
                    b.Property<int>("AgencyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<int>("AgencyTierLevelId");

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("TaxId")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("AgencyId");

                    b.HasIndex("AgencyTierLevelId");

                    b.HasIndex("CountryId");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("TabHolidayCore.Models.AgencyTierLevel", b =>
                {
                    b.Property<int>("AgencyTierLevelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("AgencyTierLevelId");

                    b.ToTable("AgencyTierLevels");
                });

            modelBuilder.Entity("TabHolidayCore.Models.ApplicationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TabHolidayCore.Models.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ActualName")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int?>("AgencyId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsAgencyOwner");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TabHolidayCore.Models.BankAccountType", b =>
                {
                    b.Property<int>("BankAccountTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("BankAccountTypeId");

                    b.ToTable("BankAccountTypes");
                });

            modelBuilder.Entity("TabHolidayCore.Models.BankDetail", b =>
                {
                    b.Property<long>("BankDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountHolderName")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("BankAccountTypeId");

                    b.Property<string>("BranchName")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<long?>("DMCId");

                    b.Property<string>("IBANCode")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("IFSCCode")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("MICRNumber")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("RoutingNumber")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("SwiftCode")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("BankDetailId");

                    b.HasIndex("BankAccountTypeId");

                    b.HasIndex("DMCId");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("TabHolidayCore.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Extention")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TabHolidayCore.Models.DMC", b =>
                {
                    b.Property<long>("DMCId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<int>("CountryId");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("OfficeNumber")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("DMCId");

                    b.HasIndex("CountryId");

                    b.ToTable("DMCs");
                });

            modelBuilder.Entity("TabHolidayCore.Models.DMCOfficial", b =>
                {
                    b.Property<long>("DMCOfficialId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("DMCId");

                    b.Property<int>("DMCOfficialTypeId");

                    b.Property<string>("EmailId")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("DMCOfficialId");

                    b.HasIndex("DMCId");

                    b.HasIndex("DMCOfficialTypeId");

                    b.ToTable("DMCOfficial");
                });

            modelBuilder.Entity("TabHolidayCore.Models.DMCOfficialType", b =>
                {
                    b.Property<int>("DMCOfficialTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("DMCOfficialTypeId");

                    b.ToTable("DMCOfficialTypes");
                });

            modelBuilder.Entity("TabHolidayCore.Models.Facility", b =>
                {
                    b.Property<short>("FacilityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Class")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<long?>("HotelId");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("FacilityId");

                    b.HasIndex("HotelId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("TabHolidayCore.Models.Hotel", b =>
                {
                    b.Property<long>("HotelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DetailedLocation")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("EmailId")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Lattitude")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Longitude")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("StarRatingId");

                    b.Property<string>("TaggedLocation")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("HotelId");

                    b.HasIndex("StarRatingId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TabHolidayCore.Models.Meal", b =>
                {
                    b.Property<short>("MealId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("HotelId");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("MealId");

                    b.HasIndex("HotelId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("TabHolidayCore.Models.StarRating", b =>
                {
                    b.Property<int>("StarRatingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("StarRatingId");

                    b.ToTable("StarRatings");
                });

            modelBuilder.Entity("TabHolidayCore.Models.State", b =>
                {
                    b.Property<long>("StateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("TabHolidayCore.Models.ApplicationRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("TabHolidayCore.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("TabHolidayCore.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>", b =>
                {
                    b.HasOne("TabHolidayCore.Models.ApplicationRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabHolidayCore.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabHolidayCore.Models.Agency", b =>
                {
                    b.HasOne("TabHolidayCore.Models.AgencyTierLevel", "AgencyTierLevel")
                        .WithMany("Agencies")
                        .HasForeignKey("AgencyTierLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabHolidayCore.Models.Country", "Country")
                        .WithMany("Agencies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabHolidayCore.Models.ApplicationUser", b =>
                {
                    b.HasOne("TabHolidayCore.Models.Agency", "Agency")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("AgencyId");
                });

            modelBuilder.Entity("TabHolidayCore.Models.BankDetail", b =>
                {
                    b.HasOne("TabHolidayCore.Models.BankAccountType", "BankAccountType")
                        .WithMany()
                        .HasForeignKey("BankAccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabHolidayCore.Models.DMC")
                        .WithMany("BankDetails")
                        .HasForeignKey("DMCId");
                });

            modelBuilder.Entity("TabHolidayCore.Models.DMC", b =>
                {
                    b.HasOne("TabHolidayCore.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabHolidayCore.Models.DMCOfficial", b =>
                {
                    b.HasOne("TabHolidayCore.Models.DMC")
                        .WithMany("DMCOfficials")
                        .HasForeignKey("DMCId");

                    b.HasOne("TabHolidayCore.Models.DMCOfficialType", "DMCOfficialType")
                        .WithMany()
                        .HasForeignKey("DMCOfficialTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabHolidayCore.Models.Facility", b =>
                {
                    b.HasOne("TabHolidayCore.Models.Hotel")
                        .WithMany("Facilities")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("TabHolidayCore.Models.Hotel", b =>
                {
                    b.HasOne("TabHolidayCore.Models.StarRating", "StarRating")
                        .WithMany()
                        .HasForeignKey("StarRatingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabHolidayCore.Models.Meal", b =>
                {
                    b.HasOne("TabHolidayCore.Models.Hotel")
                        .WithMany("Meals")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("TabHolidayCore.Models.State", b =>
                {
                    b.HasOne("TabHolidayCore.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
