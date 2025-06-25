using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class Migbarber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberID",
                table: "Hairdressers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hairdressers_BarberID",
                table: "Hairdressers",
                column: "BarberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hairdressers_Barbers_BarberID",
                table: "Hairdressers",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hairdressers_Barbers_BarberID",
                table: "Hairdressers");

            migrationBuilder.DropIndex(
                name: "IX_Hairdressers_BarberID",
                table: "Hairdressers");

            migrationBuilder.DropColumn(
                name: "BarberID",
                table: "Hairdressers");
        }
    }
}
