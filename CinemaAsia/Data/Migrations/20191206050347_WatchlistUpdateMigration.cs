using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAsia.Data.Migrations
{
    public partial class WatchlistUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId1",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_UserId1",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Watchlists");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Watchlists",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId",
                table: "Watchlists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Watchlists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Watchlists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId1",
                table: "Watchlists",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId1",
                table: "Watchlists",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
