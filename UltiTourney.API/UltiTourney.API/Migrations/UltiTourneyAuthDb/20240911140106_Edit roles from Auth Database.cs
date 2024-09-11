using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltiTourney.API.Migrations.UltiTourneyAuthDb
{
    /// <inheritdoc />
    public partial class EditrolesfromAuthDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fec49cc-7ed1-4ab1-bda1-22761e282721",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "MatchManager", "MATCHMANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624c654c-e381-4ec4-b0a6-1ccaee97d7eb",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Scoreboard", "SCOREBOARD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fec49cc-7ed1-4ab1-bda1-22761e282721",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "MatchManagerId", "MATCHMANAGERID" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624c654c-e381-4ec4-b0a6-1ccaee97d7eb",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "ScoreboardId", "SCOREBOARDID" });
        }
    }
}
