using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TabHolidayCore.Migrations
{
    public partial class TabHolidayadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    FoodTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.FoodTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InclusionTypes",
                columns: table => new
                {
                    InclusionTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InclusionTypes", x => x.InclusionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTypes",
                columns: table => new
                {
                    RestaurantTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTypes", x => x.RestaurantTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SightSeeingCategories",
                columns: table => new
                {
                    SightSeeingCategoryId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SightSeeingCategories", x => x.SightSeeingCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "StarRatings",
                columns: table => new
                {
                    StarRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRatings", x => x.StarRatingId);
                });

            migrationBuilder.CreateTable(
                name: "TransferCategories",
                columns: table => new
                {
                    TransferCategoryId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferCategories", x => x.TransferCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TransferTypes",
                columns: table => new
                {
                    TransferTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTypes", x => x.TransferTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TabMeals",
                columns: table => new
                {
                    TabMealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Breakfast = table.Column<bool>(nullable: false),
                    BreakfastRate = table.Column<decimal>(nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ClosingHour = table.Column<short>(nullable: false),
                    ClosingMinute = table.Column<short>(nullable: false),
                    Dinner = table.Column<bool>(nullable: false),
                    DinnerRate = table.Column<decimal>(nullable: false),
                    FoodTypeId = table.Column<short>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Lunch = table.Column<bool>(nullable: false),
                    LunchRate = table.Column<decimal>(nullable: false),
                    MenuDescription = table.Column<string>(type: "VARCHAR(400)", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    OpeningHour = table.Column<short>(nullable: false),
                    OpeningMinute = table.Column<short>(nullable: false),
                    RestaurantTypeId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabMeals", x => x.TabMealId);
                    table.ForeignKey(
                        name: "FK_TabMeals_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "FoodTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabMeals_RestaurantTypes_RestaurantTypeId",
                        column: x => x.RestaurantTypeId,
                        principalTable: "RestaurantTypes",
                        principalColumn: "RestaurantTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DetailedLocation = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    EmailId = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Lattitude = table.Column<float>(type: "VARCHAR(200)", nullable: false),
                    Longitude = table.Column<float>(type: "VARCHAR(200)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    StarRatingId = table.Column<int>(nullable: false),
                    TaggedLocation = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_StarRatings_StarRatingId",
                        column: x => x.StarRatingId,
                        principalTable: "StarRatings",
                        principalColumn: "StarRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SightSeeings",
                columns: table => new
                {
                    SightSeeingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlackOutEndDate = table.Column<DateTime>(nullable: false),
                    BlackOutStartDate = table.Column<DateTime>(nullable: false),
                    DetailedLocation = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DurationHour = table.Column<short>(nullable: false),
                    DurationMinute = table.Column<short>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    FullDay = table.Column<bool>(nullable: false),
                    Lattitude = table.Column<float>(type: "VARCHAR(50)", nullable: false),
                    Longitude = table.Column<float>(type: "VARCHAR(50)", nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    PTAdult = table.Column<decimal>(nullable: false),
                    PTChild = table.Column<decimal>(nullable: false),
                    PTInfant = table.Column<decimal>(nullable: false),
                    SICAdult = table.Column<decimal>(nullable: false),
                    SICChild = table.Column<decimal>(nullable: false),
                    SICInfant = table.Column<decimal>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    SightSeeingCategoryId = table.Column<short>(nullable: false),
                    StarRatingId = table.Column<int>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    TOAdult = table.Column<decimal>(nullable: false),
                    TOChild = table.Column<decimal>(nullable: false),
                    TOInfant = table.Column<decimal>(nullable: false),
                    TaggedLocation = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Thursday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SightSeeings", x => x.SightSeeingId);
                    table.ForeignKey(
                        name: "FK_SightSeeings_SightSeeingCategories_SightSeeingCategoryId",
                        column: x => x.SightSeeingCategoryId,
                        principalTable: "SightSeeingCategories",
                        principalColumn: "SightSeeingCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SightSeeings_StarRatings_StarRatingId",
                        column: x => x.StarRatingId,
                        principalTable: "StarRatings",
                        principalColumn: "StarRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DurationHour = table.Column<short>(nullable: false),
                    DurationMinute = table.Column<short>(nullable: false),
                    FromLocation = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    PremiumDateEndDate = table.Column<DateTime>(nullable: false),
                    PremiumDateStartDate = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Rates = table.Column<decimal>(nullable: false),
                    ShortDescription = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    ToLocation = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    TransferCategoryId = table.Column<short>(nullable: false),
                    TransferTypeId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_Transfers_TransferCategories_TransferCategoryId",
                        column: x => x.TransferCategoryId,
                        principalTable: "TransferCategories",
                        principalColumn: "TransferCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_TransferTypes_TransferTypeId",
                        column: x => x.TransferTypeId,
                        principalTable: "TransferTypes",
                        principalColumn: "TransferTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFacilities",
                columns: table => new
                {
                    HotelFacilityId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacilityId = table.Column<short>(nullable: false),
                    HotelId = table.Column<long>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFacilities", x => x.HotelFacilityId);
                    table.ForeignKey(
                        name: "FK_HotelFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelFacilities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelMeals",
                columns: table => new
                {
                    HotelMealId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<long>(nullable: true),
                    MealId = table.Column<short>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelMeals", x => x.HotelMealId);
                    table.ForeignKey(
                        name: "FK_HotelMeals_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inclusions",
                columns: table => new
                {
                    InclusionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DurationHour = table.Column<short>(nullable: false),
                    DurationMinute = table.Column<short>(nullable: false),
                    InclusionTypeId = table.Column<short>(nullable: false),
                    Inclusions = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    SightSeeingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inclusions", x => x.InclusionId);
                    table.ForeignKey(
                        name: "FK_Inclusions_InclusionTypes_InclusionTypeId",
                        column: x => x.InclusionTypeId,
                        principalTable: "InclusionTypes",
                        principalColumn: "InclusionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inclusions_SightSeeings_SightSeeingId",
                        column: x => x.SightSeeingId,
                        principalTable: "SightSeeings",
                        principalColumn: "SightSeeingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlackOuts",
                columns: table => new
                {
                    BlackOutId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlackOutEndDate = table.Column<DateTime>(nullable: false),
                    BlackOutStartDate = table.Column<DateTime>(nullable: false),
                    TransferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackOuts", x => x.BlackOutId);
                    table.ForeignKey(
                        name: "FK_BlackOuts_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "TransferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndHour = table.Column<short>(nullable: false),
                    EndMinute = table.Column<short>(nullable: false),
                    SightSeeingId = table.Column<int>(nullable: true),
                    StartHour = table.Column<short>(nullable: false),
                    StartMinute = table.Column<short>(nullable: false),
                    TransferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotId);
                    table.ForeignKey(
                        name: "FK_TimeSlots_SightSeeings_SightSeeingId",
                        column: x => x.SightSeeingId,
                        principalTable: "SightSeeings",
                        principalColumn: "SightSeeingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "TransferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatePerHour = table.Column<decimal>(nullable: false),
                    TransferId = table.Column<int>(nullable: true),
                    VehicleTypes = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeId);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "TransferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlackOuts_TransferId",
                table: "BlackOuts",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_StarRatingId",
                table: "Hotels",
                column: "StarRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_FacilityId",
                table: "HotelFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelMeals_HotelId",
                table: "HotelMeals",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelMeals_MealId",
                table: "HotelMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Inclusions_InclusionTypeId",
                table: "Inclusions",
                column: "InclusionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inclusions_SightSeeingId",
                table: "Inclusions",
                column: "SightSeeingId");

            migrationBuilder.CreateIndex(
                name: "IX_SightSeeings_SightSeeingCategoryId",
                table: "SightSeeings",
                column: "SightSeeingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SightSeeings_StarRatingId",
                table: "SightSeeings",
                column: "StarRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_TabMeals_FoodTypeId",
                table: "TabMeals",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TabMeals_RestaurantTypeId",
                table: "TabMeals",
                column: "RestaurantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_SightSeeingId",
                table: "TimeSlots",
                column: "SightSeeingId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_TransferId",
                table: "TimeSlots",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TransferCategoryId",
                table: "Transfers",
                column: "TransferCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TransferTypeId",
                table: "Transfers",
                column: "TransferTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_TransferId",
                table: "VehicleTypes",
                column: "TransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackOuts");

            migrationBuilder.DropTable(
                name: "HotelFacilities");

            migrationBuilder.DropTable(
                name: "HotelMeals");

            migrationBuilder.DropTable(
                name: "Inclusions");

            migrationBuilder.DropTable(
                name: "TabMeals");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "InclusionTypes");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "RestaurantTypes");

            migrationBuilder.DropTable(
                name: "SightSeeings");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "SightSeeingCategories");

            migrationBuilder.DropTable(
                name: "StarRatings");

            migrationBuilder.DropTable(
                name: "TransferCategories");

            migrationBuilder.DropTable(
                name: "TransferTypes");
        }
    }
}
