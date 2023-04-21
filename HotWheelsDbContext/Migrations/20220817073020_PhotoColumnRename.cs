using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotWheelsDbContext.Migrations
{
    /// <inheritdoc />
    public partial class PhotoColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "HotWheels",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "HotWheels",
                newName: "Photo");
        }
    }
}
