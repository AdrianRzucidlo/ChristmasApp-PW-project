using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rzucidlo.ChristmasApp.DAO.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Childers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Age = table.Column<int>(type: "int", nullable: false),
                Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                ChildrenBehaviourType = table.Column<byte>(type: "tinyint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Childers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Presents",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                ChildrenId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Presents", x => x.Id);
                table.ForeignKey(
                    name: "FK_Presents_Childers_ChildrenId",
                    column: x => x.ChildrenId,
                    principalTable: "Childers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Presents_ChildrenId",
            table: "Presents",
            column: "ChildrenId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Presents");

        migrationBuilder.DropTable(
            name: "Childers");
    }
}
