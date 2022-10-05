using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop03_RTL_Main.Migrations
{
    public partial class user_migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvertiserId",
                table: "Advertisements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AdvertiserId",
                table: "Advertisements",
                column: "AdvertiserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_AdvertiserId",
                table: "Advertisements",
                column: "AdvertiserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_AdvertiserId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_AdvertiserId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "AdvertiserId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Advertisements");
        }
    }
}
