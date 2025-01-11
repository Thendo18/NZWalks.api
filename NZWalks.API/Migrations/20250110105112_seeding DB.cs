using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Difficulties",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Difficulties", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Regions",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RegionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Regions", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Walks",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LengthInKm = table.Column<double>(type: "float", nullable: false),
            //        WalkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Walks", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Walks_Difficulties_DeficultyId",
            //            column: x => x.DifficultyId,
            //            principalTable: "Difficulties",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Walks_Regions_RegionId",
            //            column: x => x.RegionId,
            //            principalTable: "Regions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6ae01c02-521c-434e-8eaf-ab6d06e71bce"), "Hard" },
                    { new Guid("90f365ab-d024-4384-b3d5-058cb3918803"), "Medium" },
                    { new Guid("979b4832-d2e2-4d4e-9f4e-8a6503a8f017"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("81a73776-64b9-45c3-bcfa-5805788c93cd"), "ACK", "Auckland", "https://example.com/images/auckland.jpg" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Walks_DeficultyId",
            //    table: "Walks",
            //    column: "DifficultyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Walks_RegionId",
            //    table: "Walks",
            //    column: "RegionId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
