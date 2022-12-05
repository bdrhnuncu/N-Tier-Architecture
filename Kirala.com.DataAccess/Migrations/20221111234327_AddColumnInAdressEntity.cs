using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirala.com.DataAccess.Migrations
{
    public partial class AddColumnInAdressEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Addresses");
        }
    }
}
