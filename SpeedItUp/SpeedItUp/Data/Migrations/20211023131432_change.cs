using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedItUp.Data.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Slot_SlotId",
                table: "Child");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildPerson_AspNetUsers_PersonId",
                table: "ChildPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSlot_AspNetUsers_PersonId",
                table: "PersonSlot");

            migrationBuilder.DropIndex(
                name: "IX_Child_SlotId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "Child");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonSlot",
                newName: "EntertainersId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "ChildPerson",
                newName: "ParentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildPerson_PersonId",
                table: "ChildPerson",
                newName: "IX_ChildPerson_ParentsId");

            migrationBuilder.CreateTable(
                name: "ChildSlot",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    SlotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildSlot", x => new { x.ChildrenId, x.SlotsId });
                    table.ForeignKey(
                        name: "FK_ChildSlot_Child_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildSlot_Slot_SlotsId",
                        column: x => x.SlotsId,
                        principalTable: "Slot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildSlot_SlotsId",
                table: "ChildSlot",
                column: "SlotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildPerson_AspNetUsers_ParentsId",
                table: "ChildPerson",
                column: "ParentsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSlot_AspNetUsers_EntertainersId",
                table: "PersonSlot",
                column: "EntertainersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildPerson_AspNetUsers_ParentsId",
                table: "ChildPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonSlot_AspNetUsers_EntertainersId",
                table: "PersonSlot");

            migrationBuilder.DropTable(
                name: "ChildSlot");

            migrationBuilder.RenameColumn(
                name: "EntertainersId",
                table: "PersonSlot",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "ParentsId",
                table: "ChildPerson",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildPerson_ParentsId",
                table: "ChildPerson",
                newName: "IX_ChildPerson_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "SlotId",
                table: "Child",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Child_SlotId",
                table: "Child",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Slot_SlotId",
                table: "Child",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildPerson_AspNetUsers_PersonId",
                table: "ChildPerson",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSlot_AspNetUsers_PersonId",
                table: "PersonSlot",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
