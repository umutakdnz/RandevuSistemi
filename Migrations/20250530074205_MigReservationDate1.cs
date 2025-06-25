using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigReservationDate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationDateID",
                table: "Reserveds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserveds_ReservationDateID",
                table: "Reserveds",
                column: "ReservationDateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_ReservationsDate_ReservationDateID",
                table: "Reserveds",
                column: "ReservationDateID",
                principalTable: "ReservationsDate",
                principalColumn: "ReservationDateID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_ReservationsDate_ReservationDateID",
                table: "Reserveds");

            migrationBuilder.DropIndex(
                name: "IX_Reserveds_ReservationDateID",
                table: "Reserveds");

            migrationBuilder.DropColumn(
                name: "ReservationDateID",
                table: "Reserveds");
        }
    }
}
