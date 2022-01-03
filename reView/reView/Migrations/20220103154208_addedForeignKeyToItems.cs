using Microsoft.EntityFrameworkCore.Migrations;

namespace reView.Migrations
{
    public partial class addedForeignKeyToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Item");
        }
    }
}
