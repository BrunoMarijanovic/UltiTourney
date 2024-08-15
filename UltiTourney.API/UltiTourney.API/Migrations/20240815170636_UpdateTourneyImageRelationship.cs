using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltiTourney.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTourneyImageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourneys_Images_ImageId",
                table: "Tourneys");

            migrationBuilder.DropIndex(
                name: "IX_Tourneys_ImageId",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Tourneys");

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_IdImage",
                table: "Tourneys",
                column: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourneys_Images_IdImage",
                table: "Tourneys",
                column: "IdImage",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourneys_Images_IdImage",
                table: "Tourneys");

            migrationBuilder.DropIndex(
                name: "IX_Tourneys_IdImage",
                table: "Tourneys");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Tourneys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_ImageId",
                table: "Tourneys",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourneys_Images_ImageId",
                table: "Tourneys",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
