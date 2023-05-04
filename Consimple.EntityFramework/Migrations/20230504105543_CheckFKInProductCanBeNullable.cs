using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consimple.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CheckFKInProductCanBeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Checks_CheckFK",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "CheckFK",
                table: "Products",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Checks_CheckFK",
                table: "Products",
                column: "CheckFK",
                principalTable: "Checks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Checks_CheckFK",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "CheckFK",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Checks_CheckFK",
                table: "Products",
                column: "CheckFK",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
