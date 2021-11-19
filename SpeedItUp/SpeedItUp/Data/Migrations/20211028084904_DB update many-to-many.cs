using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedItUp.Data.Migrations
{
    public partial class DBupdatemanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSlot_Slot_SlotsId",
                table: "ChildSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSlot_AspNetUsers_EntertainersId",
                table: "PersonSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSlot_Slot_SlotsId",
                table: "PersonSlot");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSlot_Slot_SlotsId",
                table: "ChildSlot",
                column: "SlotsId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSlot_Person_EntertainersId",
                table: "PersonSlot",
                column: "EntertainersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSlot_Slot_SlotsId",
                table: "PersonSlot",
                column: "SlotsId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSlot_Slot_SlotsId",
                table: "ChildSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSlot_Person_EntertainersId",
                table: "PersonSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSlot_Slot_SlotsId",
                table: "PersonSlot");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSlot_Slot_SlotsId",
                table: "ChildSlot",
                column: "SlotsId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSlot_AspNetUsers_EntertainersId",
                table: "PersonSlot",
                column: "EntertainersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSlot_Slot_SlotsId",
                table: "PersonSlot",
                column: "SlotsId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
