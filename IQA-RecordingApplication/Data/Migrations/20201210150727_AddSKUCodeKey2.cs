using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQA_RecordingApplication.Data.Migrations
{
    public partial class AddSKUCodeKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SKUCodeViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SKUCodeViewModel",
                columns: table => new
                {
                    SKUCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SKUCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUCodeViewModel", x => x.SKUCodeId);
                });
        }
    }
}
