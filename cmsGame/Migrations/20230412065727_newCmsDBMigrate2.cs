using Microsoft.EntityFrameworkCore.Migrations;

namespace cmsGame.Migrations
{
    public partial class newCmsDBMigrate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BannerUrl",
                table: "tbl_Game_Android",
                newName: "Banner_Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Banner_Url",
                table: "tbl_Game_Android",
                newName: "BannerUrl");
        }
    }
}
