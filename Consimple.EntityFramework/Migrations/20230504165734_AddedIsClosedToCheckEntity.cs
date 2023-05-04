using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consimple.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsClosedToCheckEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Checks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Checks");
        }
    }
}
