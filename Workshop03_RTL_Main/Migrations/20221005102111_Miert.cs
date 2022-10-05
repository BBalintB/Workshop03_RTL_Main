using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop03_RTL_Main.Migrations
{
    public partial class Miert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvertisementId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdvertisementId",
                table: "AspNetUsers",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Advertisements_AdvertisementId",
                table: "AspNetUsers",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Advertisements_AdvertisementId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdvertisementId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "AspNetUsers");
        }
    }
}
