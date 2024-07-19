using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieFinder.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_ImageId",
                table: "Actors",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Images_ImageId",
                table: "Actors",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Images_ImageId",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_ImageId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Actors");
        }
    }
}
