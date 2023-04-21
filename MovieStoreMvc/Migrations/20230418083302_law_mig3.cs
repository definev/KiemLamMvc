using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMvc.Migrations
{
    public partial class law_mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movie",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Director",
                table: "Movie",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movie",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Movie",
                newName: "Director");

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
