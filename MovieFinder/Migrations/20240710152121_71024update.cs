using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFinder.Migrations
{
    /// <inheritdoc />
    public partial class _71024update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
