using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMvc.Migrations
{
    public partial class updatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Sections",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Sections",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Chapters",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Chapters",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Articles",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Articles",
                newName: "CreateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Sections",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Sections",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Chapters",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Chapters",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "Articles",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Articles",
                newName: "CreatedTime");
        }
    }
}
