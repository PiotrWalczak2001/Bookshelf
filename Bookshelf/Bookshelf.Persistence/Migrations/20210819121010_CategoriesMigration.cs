using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Persistence.Migrations
{
    public partial class CategoriesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModifiedBy", "Modified", "Name" },
                values: new object[,]
                {
                    { new Guid("10eb0fdb-75b4-4c33-ae6a-d07721164738"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy" },
                    { new Guid("b86dc9bd-460d-4b39-b9f1-7e7db294d89c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crime" },
                    { new Guid("c3f33488-8d6c-4323-918e-257818f73fd8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biography" },
                    { new Guid("cac47b25-478e-451b-a921-02a8f1e2d3d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4873f223-2f4a-4a47-be34-16f9e997b247"),
                column: "CategoryId",
                value: new Guid("c3f33488-8d6c-4323-918e-257818f73fd8"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b014368a-98ef-42c9-95f9-1dfe50501085"),
                column: "CategoryId",
                value: new Guid("10eb0fdb-75b4-4c33-ae6a-d07721164738"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("bb76804e-2e80-4a1b-9015-d22b0ab7aa13"),
                column: "CategoryId",
                value: new Guid("10eb0fdb-75b4-4c33-ae6a-d07721164738"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cccfca1c-016c-4d3e-ba83-a1621e42cea0"),
                column: "CategoryId",
                value: new Guid("cac47b25-478e-451b-a921-02a8f1e2d3d0"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dc0d3909-1d27-4e1c-ab08-67fee5985f65"),
                column: "CategoryId",
                value: new Guid("b86dc9bd-460d-4b39-b9f1-7e7db294d89c"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4873f223-2f4a-4a47-be34-16f9e997b247"),
                column: "Category",
                value: "Biography");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b014368a-98ef-42c9-95f9-1dfe50501085"),
                column: "Category",
                value: "Fantasy");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("bb76804e-2e80-4a1b-9015-d22b0ab7aa13"),
                column: "Category",
                value: "Fantasy");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cccfca1c-016c-4d3e-ba83-a1621e42cea0"),
                column: "Category",
                value: "Romance");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dc0d3909-1d27-4e1c-ab08-67fee5985f65"),
                column: "Category",
                value: "Crime");
        }
    }
}
