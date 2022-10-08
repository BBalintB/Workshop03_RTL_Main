using Microsoft.EntityFrameworkCore.Migrations;

namespace Workshop03_RTL_Main.Migrations
{
    public partial class database_test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_AspNetUsers_SubId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_SubId",
                table: "Subscribers");

            migrationBuilder.AlterColumn<string>(
                name: "SubId",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubId",
                table: "Subscribers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_SubId",
                table: "Subscribers",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_AspNetUsers_SubId",
                table: "Subscribers",
                column: "SubId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
