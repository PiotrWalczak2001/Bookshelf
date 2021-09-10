using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Persistence.Migrations
{
    public partial class BookBytesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "BookBytes",
                table: "Books",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookBytes",
                table: "Books");
        }
    }
}
