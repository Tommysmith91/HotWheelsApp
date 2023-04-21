using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotWheelsDbContext.Migrations
{
    /// <inheritdoc />
    public partial class RenamedHotWheelsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotWheels",
                table: "HotWheels");

            migrationBuilder.RenameTable(
                name: "HotWheels",
                newName: "HotWheel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotWheel",
                table: "HotWheel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotWheel",
                table: "HotWheel");

            migrationBuilder.RenameTable(
                name: "HotWheel",
                newName: "HotWheels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotWheels",
                table: "HotWheels",
                column: "Id");
        }
    }
}
