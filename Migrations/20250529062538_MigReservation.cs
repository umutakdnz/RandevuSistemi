using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Barbers_BarberId",
                table: "Reserveds");

            migrationBuilder.RenameColumn(
                name: "BarberId",
                table: "Reserveds",
                newName: "BarberID");

            migrationBuilder.RenameIndex(
                name: "IX_Reserveds_BarberId",
                table: "Reserveds",
                newName: "IX_Reserveds_BarberID");

            migrationBuilder.AddColumn<int>(
                name: "ReservationDaysID",
                table: "Reserveds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationHoursID",
                table: "Reserveds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservationsDays",
                columns: table => new
                {
                    ReservationDaysID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsDays", x => x.ReservationDaysID);
                    table.ForeignKey(
                        name: "FK_ReservationsDays_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "BarberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationHours",
                columns: table => new
                {
                    ReservationHoursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlot = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReservationDaysID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationHours", x => x.ReservationHoursID);
                    table.ForeignKey(
                        name: "FK_ReservationHours_ReservationsDays_ReservationDaysID",
                        column: x => x.ReservationDaysID,
                        principalTable: "ReservationsDays",
                        principalColumn: "ReservationDaysID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserveds_ReservationDaysID",
                table: "Reserveds",
                column: "ReservationDaysID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveds_ReservationHoursID",
                table: "Reserveds",
                column: "ReservationHoursID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationHours_ReservationDaysID",
                table: "ReservationHours",
                column: "ReservationDaysID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsDays_BarberId",
                table: "ReservationsDays",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Barbers_BarberID",
                table: "Reserveds",
                column: "BarberID",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_ReservationHours_ReservationHoursID",
                table: "Reserveds",
                column: "ReservationHoursID",
                principalTable: "ReservationHours",
                principalColumn: "ReservationHoursID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_ReservationsDays_ReservationDaysID",
                table: "Reserveds",
                column: "ReservationDaysID",
                principalTable: "ReservationsDays",
                principalColumn: "ReservationDaysID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Barbers_BarberID",
                table: "Reserveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_ReservationHours_ReservationHoursID",
                table: "Reserveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_ReservationsDays_ReservationDaysID",
                table: "Reserveds");

            migrationBuilder.DropTable(
                name: "ReservationHours");

            migrationBuilder.DropTable(
                name: "ReservationsDays");

            migrationBuilder.DropIndex(
                name: "IX_Reserveds_ReservationDaysID",
                table: "Reserveds");

            migrationBuilder.DropIndex(
                name: "IX_Reserveds_ReservationHoursID",
                table: "Reserveds");

            migrationBuilder.DropColumn(
                name: "ReservationDaysID",
                table: "Reserveds");

            migrationBuilder.DropColumn(
                name: "ReservationHoursID",
                table: "Reserveds");

            migrationBuilder.RenameColumn(
                name: "BarberID",
                table: "Reserveds",
                newName: "BarberId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserveds_BarberID",
                table: "Reserveds",
                newName: "IX_Reserveds_BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Barbers_BarberId",
                table: "Reserveds",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
