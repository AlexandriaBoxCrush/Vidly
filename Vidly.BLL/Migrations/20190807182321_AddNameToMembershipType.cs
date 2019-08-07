using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.BLL.Migrations
{
    public partial class AddNameToMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipType",
                maxLength: 255,
                nullable:true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
