using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.BLL.Migrations
{
    public partial class UpdateMovieDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Movies SET Genre = 'Animation', ReleaseDate = CAST('2008-06-28' AS DATETIME), DateAdded = CAST('2019-08-05' AS DATETIME), NumberInStock = 1  WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Movies SET Genre = 'Action', ReleaseDate = CAST('1977-05-25' AS DATETIME), DateAdded = CAST('2019-08-05' AS DATETIME), NumberInStock = 2  WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Movies SET Genre = 'Action', ReleaseDate = CAST('1983-06-28' AS DATETIME), DateAdded = CAST('2019-08-05' AS DATETIME), NumberInStock = 1  WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Movies SET Genre = 'Horror', ReleaseDate = CAST('2017-01-01' AS DATETIME), DateAdded = CAST('2019-08-05' AS DATETIME), NumberInStock = 6  WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Movies SET Genre = 'Animation', ReleaseDate = CAST('2012-11-02' AS DATETIME), DateAdded = CAST('2019-08-05' AS DATETIME), NumberInStock = 1  WHERE Id = 5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
