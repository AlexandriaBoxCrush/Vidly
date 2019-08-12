using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.BLL.Migrations
{
    public partial class CustomerBirthdateNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthdate",
                table: "Customers",
                nullable: false,
                defaultValue: "0000-00-00"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
