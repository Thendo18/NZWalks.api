using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class CreatingAuthenticationDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abf37abb-7a4d-4521-bdcb-48330f10f46c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff3e0c9-9904-484e-ba93-d96749aa2745");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "324e7347-e8a0-445f-842b-3b19a81e7ded", "324e7347-e8a0-445f-842b-3b19a81e7ded", "Reader", "READER" },
                    { "a6482509-00bf-4671-a07f-51672e4fd151", "a6482509-00bf-4671-a07f-51672e4fd151", "Writer", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324e7347-e8a0-445f-842b-3b19a81e7ded");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6482509-00bf-4671-a07f-51672e4fd151");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abf37abb-7a4d-4521-bdcb-48330f10f46c", "abf37abb-7a4d-4521-bdcb-48330f10f46c", "Writer", "WRITER" },
                    { "dff3e0c9-9904-484e-ba93-d96749aa2745", "dff3e0c9-9904-484e-ba93-d96749aa2745", "Reader", "READER" }
                });
        }
    }
}
