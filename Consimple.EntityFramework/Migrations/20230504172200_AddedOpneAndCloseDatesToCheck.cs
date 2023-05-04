using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consimple.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedOpneAndCloseDatesToCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedOn",
                table: "Checks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenedOn",
                table: "Checks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedOn",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "OpenedOn",
                table: "Checks");
        }
    }
}
