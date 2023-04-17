using Microsoft.EntityFrameworkCore.Migrations;

namespace cmsGame.Migrations
{
    public partial class newCmsDBMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Game_Android",
                columns: table => new
                {
                    GameCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameTitle = table.Column<int>(type: "int", nullable: false),
                    PreviewURL = table.Column<int>(type: "int", nullable: false),
                    PhysicalLocation = table.Column<int>(type: "int", nullable: false),
                    OwnerCode = table.Column<int>(type: "int", nullable: false),
                    GameTypeCode = table.Column<int>(type: "int", nullable: false),
                    GamePrice = table.Column<int>(type: "int", nullable: false),
                    AndroidVersion = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    Expire = table.Column<int>(type: "int", nullable: false),
                    Upload_Date = table.Column<int>(type: "int", nullable: false),
                    UploadBy = table.Column<int>(type: "int", nullable: false),
                    BannerUrl = table.Column<int>(type: "int", nullable: false),
                    Install = table.Column<int>(type: "int", nullable: false),
                    CurrentVersion = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    InstallK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Game_Android", x => x.GameCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Game_Android");
        }
    }
}
