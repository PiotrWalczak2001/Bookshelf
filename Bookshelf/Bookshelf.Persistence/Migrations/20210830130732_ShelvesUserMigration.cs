using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Persistence.Migrations
{
    public partial class ShelvesUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: new Guid("7022434d-0913-42e5-98ad-1db0f1a45dd4"),
                column: "UserId",
                value: new Guid("6635bdae-7604-4e98-9be3-a67618167cff"));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: new Guid("d7a45328-d6f1-4998-a93a-4785cdd415d2"),
                column: "UserId",
                value: new Guid("6635bdae-7604-4e98-9be3-a67618167cff"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: new Guid("7022434d-0913-42e5-98ad-1db0f1a45dd4"),
                column: "UserId",
                value: new Guid("925433d2-557e-45ee-8d84-017918a2d760"));

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: new Guid("d7a45328-d6f1-4998-a93a-4785cdd415d2"),
                column: "UserId",
                value: new Guid("925433d2-557e-45ee-8d84-017918a2d760"));
        }
    }
}
