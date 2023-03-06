using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival_OnlineTicket.Migrations
{
    public partial class delete_col_table_show : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Shows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
