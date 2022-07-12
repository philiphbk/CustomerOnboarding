using Microsoft.EntityFrameworkCore.Migrations;

namespace customeronboard.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    State_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.State_Id);
                });

            migrationBuilder.CreateTable(
                name: "Lgas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LGA_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Id = table.Column<int>(type: "int", nullable: false),
                    StatesState_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lgas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lgas_State_StatesState_Id",
                        column: x => x.StatesState_Id,
                        principalTable: "State",
                        principalColumn: "State_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lgas_StatesState_Id",
                table: "Lgas",
                column: "StatesState_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lgas");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
