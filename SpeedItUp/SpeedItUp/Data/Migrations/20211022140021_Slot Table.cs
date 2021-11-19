using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedItUp.Data.Migrations
{
    public partial class SlotTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlotId",
                table: "Child",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonSlot",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSlot", x => new { x.PersonId, x.SlotsId });
                    table.ForeignKey(
                        name: "FK_PersonSlot_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSlot_Slot_SlotsId",
                        column: x => x.SlotsId,
                        principalTable: "Slot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_SlotId",
                table: "Child",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSlot_SlotsId",
                table: "PersonSlot",
                column: "SlotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Slot_SlotId",
                table: "Child",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Slot_SlotId",
                table: "Child");

            migrationBuilder.DropTable(
                name: "PersonSlot");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Child_SlotId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "Child");
        }
    }
}
