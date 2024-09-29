using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltiTourney.API.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTablesTourneyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTourney_AspNetUsers_UserId",
                table: "UserTourney");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTourney_Tourneys_TourneyId",
                table: "UserTourney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTourney",
                table: "UserTourney");

            migrationBuilder.RenameTable(
                name: "UserTourney",
                newName: "UserTourneys");

            migrationBuilder.RenameIndex(
                name: "IX_UserTourney_TourneyId",
                table: "UserTourneys",
                newName: "IX_UserTourneys_TourneyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTourneys",
                table: "UserTourneys",
                columns: new[] { "UserId", "TourneyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTourneys_AspNetUsers_UserId",
                table: "UserTourneys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTourneys_Tourneys_TourneyId",
                table: "UserTourneys",
                column: "TourneyId",
                principalTable: "Tourneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTourneys_AspNetUsers_UserId",
                table: "UserTourneys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTourneys_Tourneys_TourneyId",
                table: "UserTourneys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTourneys",
                table: "UserTourneys");

            migrationBuilder.RenameTable(
                name: "UserTourneys",
                newName: "UserTourney");

            migrationBuilder.RenameIndex(
                name: "IX_UserTourneys_TourneyId",
                table: "UserTourney",
                newName: "IX_UserTourney_TourneyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTourney",
                table: "UserTourney",
                columns: new[] { "UserId", "TourneyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTourney_AspNetUsers_UserId",
                table: "UserTourney",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTourney_Tourneys_TourneyId",
                table: "UserTourney",
                column: "TourneyId",
                principalTable: "Tourneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
