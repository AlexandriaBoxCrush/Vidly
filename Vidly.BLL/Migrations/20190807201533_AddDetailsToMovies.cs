using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.BLL.Migrations
{
    public partial class AddDetailsToMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                defaultValue: "Default",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                defaultValue: "2000-01-01",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Movies",
                defaultValue: "2000-01-01",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberInStock",
                table: "Movies",
                defaultValue: 1,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Movies");
            migrationBuilder.DropColumn(
                name: "NumberInStock",
                table: "Movies");
        }
    }
}
