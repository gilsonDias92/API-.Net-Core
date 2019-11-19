using Microsoft.EntityFrameworkCore.Migrations;

namespace Kardex.API.Migrations
{
    public partial class addForeignKeyAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardList_Produce_ProduceId",
                table: "CardList");

            migrationBuilder.AlterColumn<int>(
                name: "ProduceId",
                table: "CardList",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduceId1",
                table: "CardList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardList_ProduceId1",
                table: "CardList",
                column: "ProduceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CardList_Panel_ProduceId",
                table: "CardList",
                column: "ProduceId",
                principalTable: "Panel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardList_Produce_ProduceId1",
                table: "CardList",
                column: "ProduceId1",
                principalTable: "Produce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardList_Panel_ProduceId",
                table: "CardList");

            migrationBuilder.DropForeignKey(
                name: "FK_CardList_Produce_ProduceId1",
                table: "CardList");

            migrationBuilder.DropIndex(
                name: "IX_CardList_ProduceId1",
                table: "CardList");

            migrationBuilder.DropColumn(
                name: "ProduceId1",
                table: "CardList");

            migrationBuilder.AlterColumn<int>(
                name: "ProduceId",
                table: "CardList",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CardList_Produce_ProduceId",
                table: "CardList",
                column: "ProduceId",
                principalTable: "Produce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
