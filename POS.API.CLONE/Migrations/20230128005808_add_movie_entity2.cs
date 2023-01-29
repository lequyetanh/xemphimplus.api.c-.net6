using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.API.CLONE.Migrations
{
    /// <inheritdoc />
    public partial class addmovieentity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rate = table.Column<long>(type: "bigint", nullable: false),
                    nameimage = table.Column<string>(name: "name_image", type: "nvarchar(max)", nullable: false),
                    realname = table.Column<string>(name: "real_name", type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    runtime = table.Column<long>(name: "run_time", type: "bigint", nullable: false),
                    views = table.Column<long>(type: "bigint", nullable: false),
                    releaseyear = table.Column<long>(name: "release_year", type: "bigint", nullable: false),
                    ratevote = table.Column<long>(name: "rate_vote", type: "bigint", nullable: false),
                    hrefLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "movie");
        }
    }
}
