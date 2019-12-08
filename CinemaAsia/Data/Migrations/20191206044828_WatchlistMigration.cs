using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAsia.Data.Migrations
{
    public partial class WatchlistMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlist_Movies_MovieId",
                table: "Watchlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId1",
                table: "Watchlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlist",
                table: "Watchlist");

            migrationBuilder.RenameTable(
                name: "Watchlist",
                newName: "Watchlists");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlist_UserId1",
                table: "Watchlists",
                newName: "IX_Watchlists_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlist_MovieId",
                table: "Watchlists",
                newName: "IX_Watchlists_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_Movies_MovieId",
                table: "Watchlists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId1",
                table: "Watchlists",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_Movies_MovieId",
                table: "Watchlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_AspNetUsers_UserId1",
                table: "Watchlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists");

            migrationBuilder.RenameTable(
                name: "Watchlists",
                newName: "Watchlist");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlists_UserId1",
                table: "Watchlist",
                newName: "IX_Watchlist_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlists_MovieId",
                table: "Watchlist",
                newName: "IX_Watchlist_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlist",
                table: "Watchlist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlist_Movies_MovieId",
                table: "Watchlist",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId1",
                table: "Watchlist",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
