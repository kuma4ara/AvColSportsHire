using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvColSportsHire.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Event",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");
        }
    }
}
