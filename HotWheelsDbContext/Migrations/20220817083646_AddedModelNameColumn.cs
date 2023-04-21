using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotWheelsDbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddedModelNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "HotWheels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "HotWheels");
        }
    }
}
