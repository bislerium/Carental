using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carental.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rentalrate_to_decimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RentalRate",
                table: "CarInventory",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RentalRate",
                table: "CarInventory",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
