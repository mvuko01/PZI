using Microsoft.EntityFrameworkCore.Migrations;

namespace reView.Migrations
{
    public partial class spellingMistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Caregory",
                table: "Caregory");

            migrationBuilder.RenameTable(
                name: "Caregory",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Caregory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caregory",
                table: "Caregory",
                column: "Id");
        }
    }
}
