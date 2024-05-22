using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    public partial class AddProcAndView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetOnlyBookDetails
                AS 
SELECT m.ISBN,m.Title,m.Price  FROM dbo.Books m");


            migrationBuilder.Sql(@"Create PROCEDURE dbo.getAllBookDetails
                                @bookId int
                                As 
                                SET NOCOUNT ON;
                                Select * FROM dbo.Books b 
                                Where b.BookId=@bookId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.GetOnlyBookDetails");
            migrationBuilder.Sql("DROP PROCEDURE dbo.getAllBookDetails");
        }
    }
}
