using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltiTourney.API.Migrations
{
    /// <inheritdoc />
    public partial class Migratecitycountryimagetoruneytables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCountry = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tourneys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCity = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdImage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UrlGoogleMaps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourneys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tourneys_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tourneys_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1184ffed-d8c9-4544-898e-97c1e4d08f7e"), "Mexico" },
                    { new Guid("1198e8bb-2c49-4cb4-8cc7-7c2b9a3c4033"), "Thailand" },
                    { new Guid("16d6b93f-06e5-4703-83c7-1c3e1b4c74f3"), "Nigeria" },
                    { new Guid("18a9ff9b-c4ab-4074-8751-65c3e4d08f8f"), "Peru" },
                    { new Guid("21f20f48-4e37-4b0f-b845-7d3d14a0c8b2"), "Egypt" },
                    { new Guid("27d9cbb9-c4c5-4323-83c7-fbb29a4d6c4e"), "Colombia" },
                    { new Guid("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"), "France" },
                    { new Guid("4d0fb601-e682-4fb9-b0e1-1ddac8cdb74e"), "Indonesia" },
                    { new Guid("4ed1d5fa-3b0d-4b82-8fd3-48235c56a22c"), "Singapore" },
                    { new Guid("5ed14b71-76f2-4d3a-8614-cf4ec2f526f2"), "Australia" },
                    { new Guid("68cb11c9-f00b-4665-bb7d-d9e1a0a6de27"), "China" },
                    { new Guid("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"), "Germany" },
                    { new Guid("778c9814-c905-4f86-8401-8dcb9a6fbd53"), "India" },
                    { new Guid("7e96d6d1-ea9a-4f83-a9d9-dedb9f6dbe59"), "Brazil" },
                    { new Guid("7f46b9f7-7cc5-490d-b0e1-2ef708c42e39"), "Chile" },
                    { new Guid("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"), "United States" },
                    { new Guid("88d9d635-e31a-4979-91f7-ef70f69c41db"), "Portugal" },
                    { new Guid("9a5b5d3d-4e63-4f2e-b409-3fdbb8eaa5b9"), "Saudi Arabia" },
                    { new Guid("9d64f83c-682c-4cd7-84e6-6db3c0a2d45a"), "United Kingdom" },
                    { new Guid("9fcbad7d-dc1a-4920-8a24-cb2b5b5cfa56"), "Malaysia" },
                    { new Guid("a7dff340-8df9-4a4c-bf49-7a70f2ef0b4e"), "Turkey" },
                    { new Guid("a8f65470-1d95-4f2e-bca0-e3b6144762aa"), "Canada" },
                    { new Guid("b5b65a27-02ea-4c9c-9e48-1c5f5a3763d8"), "South Korea" },
                    { new Guid("b793f8a7-7be2-4634-80da-b0d10db6b0d3"), "Italy" },
                    { new Guid("b7e3776f-c0f3-46ad-83b1-631b97f7fc4a"), "South Africa" },
                    { new Guid("bc5a9391-13c0-4679-8bc7-60d6600ff621"), "Argentina" },
                    { new Guid("cd16c2b9-82bb-4c18-8574-8127c5a028ec"), "Russia" },
                    { new Guid("cf16c3c9-73cc-4c1f-96f5-1c7e5a0a9e4c"), "Venezuela" },
                    { new Guid("d196f2c8-0fc3-4965-b19c-f44e2a042dda"), "Japan" },
                    { new Guid("d28c5d96-23da-46fd-b59f-5eebc284fdc5"), "Vietnam" },
                    { new Guid("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"), "España" },
                    { new Guid("da6d27f3-6213-43f2-9a5c-d6b9a324c4d3"), "New Zealand" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IdCountry", "Name" },
                values: new object[,]
                {
                    { new Guid("26c2a2da-7b14-4901-9447-19f5cfa42e15"), new Guid("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"), "New York" },
                    { new Guid("39bc8a6d-87e4-45b7-8f27-7b7487e3b0e3"), new Guid("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"), "Madrid" },
                    { new Guid("4b73fa7d-ffdf-4fa1-8f77-bd6459c9e91e"), new Guid("d3484d6e-97d4-4727-8b6f-50b679f9d5d2"), "Girona" },
                    { new Guid("74e29a0c-7d0d-4b4b-b88a-1d68a7e7b028"), new Guid("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"), "Munich" },
                    { new Guid("8c8c08d3-665c-40d5-a96a-44eb76e89bb1"), new Guid("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"), "Lyon" },
                    { new Guid("aa3e69d9-b7e3-4b64-bc5e-6cb8c6f52a15"), new Guid("84e22678-1db4-45b4-8f5f-1b4e75d8e90c"), "Los Angeles" },
                    { new Guid("e60c7b5e-b72b-4f85-a1c3-eadc8a9d89b3"), new Guid("2b9923a8-7fd0-4d02-bd02-2cc702b4c78b"), "Paris" },
                    { new Guid("fea6d774-33df-49d3-bc3f-e1c582a7dc0c"), new Guid("6d4f0f7c-9e9c-4f07-b58c-303b8f60b9a4"), "Berlin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IdCountry",
                table: "Cities",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_CityId",
                table: "Tourneys",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourneys_ImageId",
                table: "Tourneys",
                column: "ImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tourneys");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
