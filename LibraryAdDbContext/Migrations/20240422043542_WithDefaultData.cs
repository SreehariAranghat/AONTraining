using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAdDbContext.Migrations
{
    /// <inheritdoc />
    public partial class WithDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedDate", "DeletedDate", "Description", "LastModifiedDate", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "Robin Sharma", new DateTime(2024, 4, 22, 10, 5, 41, 992, DateTimeKind.Local).AddTicks(241), null, "", null, "Monk Who sold his ferrari", "Monk Who sold his ferrari" },
                    { 2, "Bram Stocker", new DateTime(2024, 4, 22, 10, 5, 41, 992, DateTimeKind.Local).AddTicks(244), null, "", null, "Dracula", "Dracula" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "LastModifiedDate", "Name", "Password" },
                values: new object[] { 1, new DateTime(2024, 4, 22, 10, 5, 41, 992, DateTimeKind.Local).AddTicks(136), null, "sreehariis@gmail.com", null, "Sree", "abcd@1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
