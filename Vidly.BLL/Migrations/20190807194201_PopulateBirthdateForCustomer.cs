using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.BLL.Migrations
{
    public partial class PopulateBirthdateForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('2009-05-25' AS DATETIME) WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('1996-07-05' AS DATETIME) WHERE Id = 5");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
