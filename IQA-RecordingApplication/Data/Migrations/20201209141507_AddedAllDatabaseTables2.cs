using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQA_RecordingApplication.Data.Migrations
{
    public partial class AddedAllDatabaseTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCodes",
                columns: table => new
                {
                    CustomerCodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCodes", x => x.CustomerCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SKUCodes",
                columns: table => new
                {
                    SKUCodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SKUCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUCodes", x => x.SKUCodeId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorMessageTracks",
                columns: table => new
                {
                    ErrorMessageTrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    SKUCodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorMessageTracks", x => x.ErrorMessageTrackId);
                    table.ForeignKey(
                        name: "FK_ErrorMessageTracks_CustomerCodes_CustomerCodeId",
                        column: x => x.CustomerCodeId,
                        principalTable: "CustomerCodes",
                        principalColumn: "CustomerCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErrorMessageTracks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErrorMessageTracks_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErrorMessageTracks_SKUCodes_SKUCodeId",
                        column: x => x.SKUCodeId,
                        principalTable: "SKUCodes",
                        principalColumn: "SKUCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ErrorMessages",
                columns: table => new
                {
                    ErrorMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessageTrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorMessages", x => x.ErrorMessageId);
                    table.ForeignKey(
                        name: "FK_ErrorMessages_ErrorMessageTracks_ErrorMessageTrackId",
                        column: x => x.ErrorMessageTrackId,
                        principalTable: "ErrorMessageTracks",
                        principalColumn: "ErrorMessageTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessages_ErrorMessageTrackId",
                table: "ErrorMessages",
                column: "ErrorMessageTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_CustomerCodeId",
                table: "ErrorMessageTracks",
                column: "CustomerCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_ProductId",
                table: "ErrorMessageTracks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_ProductTypeId",
                table: "ErrorMessageTracks",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_SKUCodeId",
                table: "ErrorMessageTracks",
                column: "SKUCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorMessages");

            migrationBuilder.DropTable(
                name: "ErrorMessageTracks");

            migrationBuilder.DropTable(
                name: "CustomerCodes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "SKUCodes");
        }
    }
}
