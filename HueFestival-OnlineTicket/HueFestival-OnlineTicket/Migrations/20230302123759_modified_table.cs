using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival_OnlineTicket.Migrations
{
    public partial class modified_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ShowCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ShowCategories");
        }
    }
}
