using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQA_RecordingApplication.Data.Migrations
{
    public partial class AddedAllDatabaseTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SKUCodeViewModel",
                columns: table => new
                {
                    SKUCodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SKUCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUCodeViewModel", x => x.SKUCodeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SKUCodeViewModel");
        }
    }
}
