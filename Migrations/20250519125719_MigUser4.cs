using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Migrations
{
    /// <inheritdoc />
    public partial class MigUser4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberId",
                table: "CustomerComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerComments_BarberId",
                table: "CustomerComments",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerComments_Barbers_BarberId",
                table: "CustomerComments",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "BarberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerComments_Barbers_BarberId",
                table: "CustomerComments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerComments_BarberId",
                table: "CustomerComments");

            migrationBuilder.DropColumn(
                name: "BarberId",
                table: "CustomerComments");
        }
    }
}
