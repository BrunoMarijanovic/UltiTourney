using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltiTourney.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTourneyCityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourneys_Cities_CityId",
                table: "Tourneys");

            migrationBuilder.DropIndex(
                name: "IX_Tourneys_CityId",
                table: "Tourneys");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Tourneys");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdImage",
                table: "Tourneys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_IdCity",
                table: "Tourneys",
                column: "IdCity");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourneys_Cities_IdCity",
                table: "Tourneys",
                column: "IdCity",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourneys_Cities_IdCity",
                table: "Tourneys");

            migrationBuilder.DropIndex(
                name: "IX_Tourneys_IdCity",
                table: "Tourneys");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdImage",
                table: "Tourneys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Tourneys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_CityId",
                table: "Tourneys",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourneys_Cities_CityId",
                table: "Tourneys",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
