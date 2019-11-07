using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kardex.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Board_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Panel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BoardId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Panel_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Panel_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    PanelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Panel_PanelId",
                        column: x => x.PanelId,
                        principalTable: "Panel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PanelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produce_Panel_PanelId",
                        column: x => x.PanelId,
                        principalTable: "Panel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Creatable = table.Column<bool>(nullable: false),
                    ProduceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardList_Produce_ProduceId",
                        column: x => x.ProduceId,
                        principalTable: "Produce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: true),
                    Lables = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CardListId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_CardList_CardListId",
                        column: x => x.CardListId,
                        principalTable: "CardList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Board_UserId",
                table: "Board",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardListId",
                table: "Card",
                column: "CardListId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_UserId",
                table: "Card",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardList_ProduceId",
                table: "CardList",
                column: "ProduceId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_PanelId",
                table: "Member",
                column: "PanelId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserId",
                table: "Member",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Panel_BoardId",
                table: "Panel",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Panel_UserId",
                table: "Panel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Produce_PanelId",
                table: "Produce",
                column: "PanelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "CardList");

            migrationBuilder.DropTable(
                name: "Produce");

            migrationBuilder.DropTable(
                name: "Panel");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
