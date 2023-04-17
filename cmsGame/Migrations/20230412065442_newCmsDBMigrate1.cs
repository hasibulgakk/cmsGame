using Microsoft.EntityFrameworkCore.Migrations;

namespace cmsGame.Migrations
{
    public partial class newCmsDBMigrate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadBy",
                table: "tbl_Game_Android",
                newName: "Upload_By");

            migrationBuilder.RenameColumn(
                name: "PreviewURL",
                table: "tbl_Game_Android",
                newName: "Preview_URL");

            migrationBuilder.RenameColumn(
                name: "PhysicalLocation",
                table: "tbl_Game_Android",
                newName: "Physical_Location");

            migrationBuilder.RenameColumn(
                name: "OwnerCode",
                table: "tbl_Game_Android",
                newName: "Owner_Code");

            migrationBuilder.RenameColumn(
                name: "GameTypeCode",
                table: "tbl_Game_Android",
                newName: "Game_Type_Code");

            migrationBuilder.RenameColumn(
                name: "GameTitle",
                table: "tbl_Game_Android",
                newName: "Game_Title");

            migrationBuilder.RenameColumn(
                name: "GamePrice",
                table: "tbl_Game_Android",
                newName: "Game_Price");

            migrationBuilder.RenameColumn(
                name: "AndroidVersion",
                table: "tbl_Game_Android",
                newName: "Android_Version");

            migrationBuilder.RenameColumn(
                name: "GameCode",
                table: "tbl_Game_Android",
                newName: "Game_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Upload_By",
                table: "tbl_Game_Android",
                newName: "UploadBy");

            migrationBuilder.RenameColumn(
                name: "Preview_URL",
                table: "tbl_Game_Android",
                newName: "PreviewURL");

            migrationBuilder.RenameColumn(
                name: "Physical_Location",
                table: "tbl_Game_Android",
                newName: "PhysicalLocation");

            migrationBuilder.RenameColumn(
                name: "Owner_Code",
                table: "tbl_Game_Android",
                newName: "OwnerCode");

            migrationBuilder.RenameColumn(
                name: "Game_Type_Code",
                table: "tbl_Game_Android",
                newName: "GameTypeCode");

            migrationBuilder.RenameColumn(
                name: "Game_Title",
                table: "tbl_Game_Android",
                newName: "GameTitle");

            migrationBuilder.RenameColumn(
                name: "Game_Price",
                table: "tbl_Game_Android",
                newName: "GamePrice");

            migrationBuilder.RenameColumn(
                name: "Android_Version",
                table: "tbl_Game_Android",
                newName: "AndroidVersion");

            migrationBuilder.RenameColumn(
                name: "Game_Code",
                table: "tbl_Game_Android",
                newName: "GameCode");
        }
    }
}
