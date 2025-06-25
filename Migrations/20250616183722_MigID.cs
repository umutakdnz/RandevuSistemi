using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberID",
                table: "ReservationsDate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BarberID",
                table: "ReservationHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsDate_BarberID",
                table: "ReservationsDate",
                column: "BarberID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationHours_BarberID",
                table: "ReservationHours",
                column: "BarberID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationHours_Barbers_BarberID",
                table: "ReservationHours",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsDate_Barbers_BarberID",
                table: "ReservationsDate",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationHours_Barbers_BarberID",
                table: "ReservationHours");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsDate_Barbers_BarberID",
                table: "ReservationsDate");

            migrationBuilder.DropIndex(
                name: "IX_ReservationsDate_BarberID",
                table: "ReservationsDate");

            migrationBuilder.DropIndex(
                name: "IX_ReservationHours_BarberID",
                table: "ReservationHours");

            migrationBuilder.DropColumn(
                name: "BarberID",
                table: "ReservationsDate");

            migrationBuilder.DropColumn(
                name: "BarberID",
                table: "ReservationHours");
        }
    }
}
