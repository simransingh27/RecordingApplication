using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IQA_RecordingApplication.Data.Migrations
{
    public partial class AddDB12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessageTracks_CustomerCodes_CustomerCodeId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessageTracks_ProductTypes_ProductTypeId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessageTracks_SKUCodes_SkuId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropTable(
                name: "SKUCodes");

            migrationBuilder.DropIndex(
                name: "IX_ErrorMessageTracks_CustomerCodeId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropIndex(
                name: "IX_ErrorMessageTracks_ProductTypeId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropIndex(
                name: "IX_ErrorMessageTracks_SkuId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ErrorMessageTracks");

            migrationBuilder.DropColumn(
                name: "CustomerCodeId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropColumn(
                name: "SkuId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ErrorMessageTracks");

            migrationBuilder.RenameColumn(
                name: "SKUCodeId",
                table: "ErrorMessageTracks",
                newName: "ErrorMessageId");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CustomerCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_ErrorMessageId",
                table: "ErrorMessageTracks",
                column: "ErrorMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCodes_ProductId",
                table: "CustomerCodes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCodes_Products_ProductId",
                table: "CustomerCodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessageTracks_ErrorMessages_ErrorMessageId",
                table: "ErrorMessageTracks",
                column: "ErrorMessageId",
                principalTable: "ErrorMessages",
                principalColumn: "ErrorMessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCodes_Products_ProductId",
                table: "CustomerCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessageTracks_ErrorMessages_ErrorMessageId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ErrorMessageTracks_ErrorMessageId",
                table: "ErrorMessageTracks");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCodes_ProductId",
                table: "CustomerCodes");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CustomerCodes");

            migrationBuilder.RenameColumn(
                name: "ErrorMessageId",
                table: "ErrorMessageTracks",
                newName: "SKUCodeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ErrorMessageTracks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CustomerCodeId",
                table: "ErrorMessageTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "ErrorMessageTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkuId",
                table: "ErrorMessageTracks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ErrorMessageTracks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SKUCodes",
                columns: table => new
                {
                    SKUCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SKUCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUCodes", x => x.SKUCodeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_CustomerCodeId",
                table: "ErrorMessageTracks",
                column: "CustomerCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_ProductTypeId",
                table: "ErrorMessageTracks",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessageTracks_SkuId",
                table: "ErrorMessageTracks",
                column: "SkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessageTracks_CustomerCodes_CustomerCodeId",
                table: "ErrorMessageTracks",
                column: "CustomerCodeId",
                principalTable: "CustomerCodes",
                principalColumn: "CustomerCodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessageTracks_ProductTypes_ProductTypeId",
                table: "ErrorMessageTracks",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessageTracks_SKUCodes_SkuId",
                table: "ErrorMessageTracks",
                column: "SkuId",
                principalTable: "SKUCodes",
                principalColumn: "SKUCodeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
