using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigUserUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberId",
                table: "Reserveds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarberId",
                table: "Reserveds");

            migrationBuilder.AddColumn<string>(
                name: "Barber",
                table: "Reserveds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
