using Microsoft.EntityFrameworkCore.Migrations;

namespace IQA_RecordingApplication.Data.Migrations
{
    public partial class AddDB13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorMessages_ErrorMessageTracks_ErrorMessageTrackId",
                table: "ErrorMessages");

            migrationBuilder.DropIndex(
                name: "IX_ErrorMessages_ErrorMessageTrackId",
                table: "ErrorMessages");

            migrationBuilder.DropColumn(
                name: "ErrorMessageTrackId",
                table: "ErrorMessages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErrorMessageTrackId",
                table: "ErrorMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ErrorMessages_ErrorMessageTrackId",
                table: "ErrorMessages",
                column: "ErrorMessageTrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorMessages_ErrorMessageTracks_ErrorMessageTrackId",
                table: "ErrorMessages",
                column: "ErrorMessageTrackId",
                principalTable: "ErrorMessageTracks",
                principalColumn: "ErrorMessageTrackId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
