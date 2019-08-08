using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.BLL.Migrations
{
    public partial class UpdateExistingCustomersBirthdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('2009-04-15' AS DATETIME) WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('1995-08-13' AS DATETIME) WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('2004-09-25' AS DATETIME) WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('1996-11-08' AS DATETIME) WHERE Id = 6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
