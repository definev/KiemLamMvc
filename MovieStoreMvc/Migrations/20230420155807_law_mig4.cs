using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMvc.Migrations
{
    public partial class law_mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "ChuongMuc",
                newName: "TenChuong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenChuong",
                table: "ChuongMuc",
                newName: "GenreName");
        }
    }
}
