using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMvc.Migrations
{
    public partial class law_mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieImage",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieImage",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
