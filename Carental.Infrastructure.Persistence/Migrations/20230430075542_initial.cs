using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carental.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountOffers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ByteSize = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Files_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Files_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Files",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Files_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarInventories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentalRate = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarInventories_Cars_Id",
                        column: x => x.Id,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarInventoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    ReturnOrCancelDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountOfferId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RentPrice = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRentals_CarInventories_CarInventoryId",
                        column: x => x.CarInventoryId,
                        principalTable: "CarInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentals_DiscountOffers_DiscountOfferId",
                        column: x => x.DiscountOfferId,
                        principalTable: "DiscountOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarDamages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DamageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewStatus = table.Column<int>(type: "int", nullable: false),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Charge = table.Column<int>(type: "int", nullable: false),
                    IsChargePaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDamages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDamages_CarRentals_Id",
                        column: x => x.Id,
                        principalTable: "CarRentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarInventoryId",
                table: "CarRentals",
                column: "CarInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CustomerId",
                table: "CarRentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_DiscountOfferId",
                table: "CarRentals",
                column: "DiscountOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImageId",
                table: "Cars",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DocumentId",
                table: "Customers",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ImageId",
                table: "Customers",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDamages");

            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "CarInventories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DiscountOffers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
