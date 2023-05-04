using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consimple.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeToClientService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Clients",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Clients",
                newName: "CreateOn");
        }
    }
}
