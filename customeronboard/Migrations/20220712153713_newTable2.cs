using Microsoft.EntityFrameworkCore.Migrations;

namespace customeronboard.Migrations
{
    public partial class newTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lgas_State_StatesState_Id",
                table: "Lgas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lgas",
                table: "Lgas");

            migrationBuilder.DropIndex(
                name: "IX_Lgas_StatesState_Id",
                table: "Lgas");

            migrationBuilder.DropColumn(
                name: "StatesState_Id",
                table: "Lgas");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "StateTable");

            migrationBuilder.RenameTable(
                name: "Lgas",
                newName: "LGATable");

            migrationBuilder.AddColumn<int>(
                name: "Lga_Id",
                table: "LGATable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StateTable",
                table: "StateTable",
                column: "State_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LGATable",
                table: "LGATable",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StateTable",
                table: "StateTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LGATable",
                table: "LGATable");

            migrationBuilder.DropColumn(
                name: "Lga_Id",
                table: "LGATable");

            migrationBuilder.RenameTable(
                name: "StateTable",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "LGATable",
                newName: "Lgas");

            migrationBuilder.AddColumn<int>(
                name: "StatesState_Id",
                table: "Lgas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "State_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lgas",
                table: "Lgas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lgas_StatesState_Id",
                table: "Lgas",
                column: "StatesState_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lgas_State_StatesState_Id",
                table: "Lgas",
                column: "StatesState_Id",
                principalTable: "State",
                principalColumn: "State_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
