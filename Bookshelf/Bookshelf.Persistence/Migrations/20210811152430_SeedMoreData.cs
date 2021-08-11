using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Persistence.Migrations
{
    public partial class SeedMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "925433D2-557E-45EE-8D84-017918A2D760");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "ShelfBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "ShelfBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ShelfBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "CoverImageUrl", "Created", "CreatedBy", "Description", "LastModifiedBy", "Modified", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("dc0d3909-1d27-4e1c-ab08-67fee5985f65"), "Author1", "Crime", "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Description1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book1" },
                    { new Guid("4873f223-2f4a-4a47-be34-16f9e997b247"), "Author1", "Biography", "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Description2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book2" },
                    { new Guid("cccfca1c-016c-4d3e-ba83-a1621e42cea0"), "Author2", "Romance", "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Description3", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book3" }
                });

            migrationBuilder.UpdateData(
                table: "ShelfBooks",
                keyColumn: "Id",
                keyValue: new Guid("77871a16-60a9-495f-ab45-a5a1de113418"),
                columns: new[] { "Author", "CoverImageUrl", "Title" },
                values: new object[] { "Andrzej Sapkowski", "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", "Sword of Destiny" });

            migrationBuilder.UpdateData(
                table: "ShelfBooks",
                keyColumn: "Id",
                keyValue: new Guid("cf909b3a-01ce-4c9f-a3e9-5740a298378d"),
                columns: new[] { "Author", "CoverImageUrl", "Title" },
                values: new object[] { "Andrzej Sapkowski", "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", "The Last Wish" });

            migrationBuilder.InsertData(
                table: "ShelfBooks",
                columns: new[] { "Id", "Author", "BookId", "CoverImageUrl", "Created", "CreatedBy", "LastModifiedBy", "Modified", "ShelfId", "Title" },
                values: new object[,]
                {
                    { new Guid("8aad8e9a-3982-4eda-8257-084e5216c02f"), "Author1", new Guid("dc0d3909-1d27-4e1c-ab08-67fee5985f65"), "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d7a45328-d6f1-4998-a93a-4785cdd415d2"), "Book1" },
                    { new Guid("ee38899d-a6f4-49fc-835e-bc1d0f0a7997"), "Author1", new Guid("4873f223-2f4a-4a47-be34-16f9e997b247"), "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d7a45328-d6f1-4998-a93a-4785cdd415d2"), "Book2" },
                    { new Guid("afbfc8d5-fe04-4e7a-a339-e0f43144321f"), "Author1", new Guid("dc0d3909-1d27-4e1c-ab08-67fee5985f65"), "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7022434d-0913-42e5-98ad-1db0f1a45dd4"), "Book1" },
                    { new Guid("4d5d90da-9d71-4145-b7de-ba95cd078915"), "Author2", new Guid("cccfca1c-016c-4d3e-ba83-a1621e42cea0"), "https://cdn.pixabay.com/photo/2017/05/03/21/16/book-2282152_960_720.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7022434d-0913-42e5-98ad-1db0f1a45dd4"), "Book3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelfBooks_ShelfId",
                table: "ShelfBooks",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfBooks_Shelves_ShelfId",
                table: "ShelfBooks",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelfBooks_Shelves_ShelfId",
                table: "ShelfBooks");

            migrationBuilder.DropIndex(
                name: "IX_ShelfBooks_ShelfId",
                table: "ShelfBooks");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4873f223-2f4a-4a47-be34-16f9e997b247"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cccfca1c-016c-4d3e-ba83-a1621e42cea0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dc0d3909-1d27-4e1c-ab08-67fee5985f65"));

            migrationBuilder.DeleteData(
                table: "ShelfBooks",
                keyColumn: "Id",
                keyValue: new Guid("4d5d90da-9d71-4145-b7de-ba95cd078915"));

            migrationBuilder.DeleteData(
                table: "ShelfBooks",
                keyColumn: "Id",
                keyValue: new Guid("8aad8e9a-3982-4eda-8257-084e5216c02f"));

            migrationBuilder.DeleteData(
                table: "ShelfBooks",
                keyColumn: "Id",
                keyValue: new Guid("afbfc8d5-fe04-4e7a-a339-e0f43144321f"));

            migrationBuilder.DeleteData(
                table: "ShelfBooks",
                keyColumn: "Id",
                keyValue: new Guid("ee38899d-a6f4-49fc-835e-bc1d0f0a7997"));

            migrationBuilder.DropColumn(
                name: "Author",
                table: "ShelfBooks");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "ShelfBooks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ShelfBooks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "925433D2-557E-45EE-8D84-017918A2D760", 0, "a272545c-6134-461d-89c0-b0b1f22408cc", "jan@testowy.com", true, "Jan", "Testowy", false, null, null, null, null, null, false, "eac9071c-297a-47ee-8429-0713d4871dc0", false, "testuser" });
        }
    }
}
