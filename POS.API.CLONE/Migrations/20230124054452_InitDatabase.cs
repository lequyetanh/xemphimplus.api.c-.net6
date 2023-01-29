using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.API.CLONE.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    passcode = table.Column<string>(name: "pass_code", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "nvarchar(12)", maxLength: 12, nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    provinceid = table.Column<long>(name: "province_id", type: "bigint", nullable: true),
                    districtid = table.Column<long>(name: "district_id", type: "bigint", nullable: true),
                    wardid = table.Column<long>(name: "ward_id", type: "bigint", nullable: true),
                    sex = table.Column<byte>(type: "tinyint", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false),
                    type = table.Column<byte>(type: "tinyint", nullable: false),
                    userAdded = table.Column<long>(type: "bigint", nullable: false),
                    userUpdated = table.Column<long>(type: "bigint", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isdelete = table.Column<bool>(name: "is_delete", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category_province",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipcode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    languagecode = table.Column<string>(name: "language_code", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    statusid = table.Column<byte>(name: "status_id", type: "tinyint", nullable: false),
                    istransport = table.Column<bool>(name: "is_transport", type: "bit", nullable: false),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "bit", nullable: false),
                    userAdded = table.Column<long>(type: "bigint", nullable: false),
                    userUpdated = table.Column<long>(type: "bigint", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isdelete = table.Column<bool>(name: "is_delete", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_province", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_user");

            migrationBuilder.DropTable(
                name: "category_province");
        }
    }
}
