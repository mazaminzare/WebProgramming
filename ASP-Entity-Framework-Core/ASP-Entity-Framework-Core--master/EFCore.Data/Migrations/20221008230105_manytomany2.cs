using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    public partial class manytomany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthor_Fluent_Authors_AuthorId",
                table: "Fluent_BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthor_Fluent_Books_BookId",
                table: "Fluent_BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthor",
                table: "Fluent_BookAuthor");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthor",
                newName: "Fluent_BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthor_AuthorId",
                table: "Fluent_BookAuthors",
                newName: "IX_Fluent_BookAuthors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthors",
                table: "Fluent_BookAuthors",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthors_Fluent_Authors_AuthorId",
                table: "Fluent_BookAuthors",
                column: "AuthorId",
                principalTable: "Fluent_Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthors_Fluent_Books_BookId",
                table: "Fluent_BookAuthors",
                column: "BookId",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthors_Fluent_Authors_AuthorId",
                table: "Fluent_BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthors_Fluent_Books_BookId",
                table: "Fluent_BookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthors",
                table: "Fluent_BookAuthors");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthors",
                newName: "Fluent_BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthors_AuthorId",
                table: "Fluent_BookAuthor",
                newName: "IX_Fluent_BookAuthor_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthor",
                table: "Fluent_BookAuthor",
                columns: new[] { "BookId", "AuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthor_Fluent_Authors_AuthorId",
                table: "Fluent_BookAuthor",
                column: "AuthorId",
                principalTable: "Fluent_Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthor_Fluent_Books_BookId",
                table: "Fluent_BookAuthor",
                column: "BookId",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
