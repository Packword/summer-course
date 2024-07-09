using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCodingServer.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6ae12c17-6198-4eac-baa4-13821bfddea8"), "Maxim" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[] { new Guid("1c79cfc7-d239-4b17-9cd3-98d3f9dc30e3"), "123456", "098765432", new Guid("6ae12c17-6198-4eac-baa4-13821bfddea8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1c79cfc7-d239-4b17-9cd3-98d3f9dc30e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ae12c17-6198-4eac-baa4-13821bfddea8"));
        }
    }
}
