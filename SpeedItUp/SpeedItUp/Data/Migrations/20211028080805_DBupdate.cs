using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeedItUp.Data.Migrations
{
    public partial class DBupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Profile_ProfileId",
                table: "Child");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildPerson_AspNetUsers_ParentsId",
                table: "ChildPerson");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Child_ProfileId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Child");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildPerson_Person_ParentsId",
                table: "ChildPerson",
                column: "ParentsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildPerson_Person_ParentsId",
                table: "ChildPerson");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Child",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_ProfileId",
                table: "Child",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Profile_ProfileId",
                table: "Child",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildPerson_AspNetUsers_ParentsId",
                table: "ChildPerson",
                column: "ParentsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
