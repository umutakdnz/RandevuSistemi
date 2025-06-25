using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reserveds_BarberId",
                table: "Reserveds",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveds_Barbers_BarberId",
                table: "Reserveds",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserveds_Barbers_BarberId",
                table: "Reserveds");

            migrationBuilder.DropIndex(
                name: "IX_Reserveds_BarberId",
                table: "Reserveds");
        }
    }
}
