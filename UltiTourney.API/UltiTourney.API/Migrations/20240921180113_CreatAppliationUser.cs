using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltiTourney.API.Migrations
{
    /// <inheritdoc />
    public partial class CreatAppliationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTourney",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TourneyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTourney", x => new { x.UserId, x.TourneyId });
                    table.ForeignKey(
                        name: "FK_UserTourney_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTourney_Tourneys_TourneyId",
                        column: x => x.TourneyId,
                        principalTable: "Tourneys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTourney_TourneyId",
                table: "UserTourney",
                column: "TourneyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTourney");
        }
    }
}
