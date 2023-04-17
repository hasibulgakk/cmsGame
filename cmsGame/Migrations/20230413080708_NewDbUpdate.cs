using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cmsGame.Migrations
{
    public partial class NewDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Game_Java",
                columns: table => new
                {
                    Game_Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Game_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preview_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Game_Owner_Code = table.Column<int>(type: "int", nullable: false),
                    Game_Type_Code = table.Column<int>(type: "int", nullable: false),
                    Game_Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upload_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Upload_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ismapped = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner_Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Game_Java", x => x.Game_Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Game_Java");
        }
    }
}
