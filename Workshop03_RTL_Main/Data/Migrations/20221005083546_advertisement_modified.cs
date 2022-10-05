using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop03_RTL_Main.Data.Migrations
{
    public partial class advertisement_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSubscribers",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSubscribers",
                table: "Advertisements");
        }
    }
}
