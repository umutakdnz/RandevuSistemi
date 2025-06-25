using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigReservedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_ReservationsDate_ReservationDateID",
                table: "Reserveds");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationDateID",
                table: "Reserveds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_ReservationsDate_ReservationDateID",
                table: "Reserveds",
                column: "ReservationDateID",
                principalTable: "ReservationsDate",
                principalColumn: "ReservationDateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_ReservationsDate_ReservationDateID",
                table: "Reserveds");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationDateID",
                table: "Reserveds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_ReservationsDate_ReservationDateID",
                table: "Reserveds",
                column: "ReservationDateID",
                principalTable: "ReservationsDate",
                principalColumn: "ReservationDateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
