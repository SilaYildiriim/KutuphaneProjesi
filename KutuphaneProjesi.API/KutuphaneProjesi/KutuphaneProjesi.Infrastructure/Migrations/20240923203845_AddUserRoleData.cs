using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KutuphaneProjesi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Discriminator", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1e5f19f8-43b0-45fe-b276-f37d9a6541d8"), new Guid("5a2b12d5-b30d-4e67-b31f-5fe19a367485"), null, "UserRole", null, null },
                    { new Guid("66d20726-5805-4468-86f2-63ae89d402c1"), new Guid("7ca69cfa-88fc-4569-aed2-a1becaf4f9a6"), null, "UserRole", null, null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a2b12d5-b30d-4e67-b31f-5fe19a367485"),
                column: "ConcurrencyStamp",
                value: "bc6a5c7a-aff4-4e6c-8874-16815ed68065");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7ca69cfa-88fc-4569-aed2-a1becaf4f9a6"),
                column: "ConcurrencyStamp",
                value: "c7009578-b8c0-4676-9a16-c6d3fbccc881");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1e5f19f8-43b0-45fe-b276-f37d9a6541d8"), new Guid("5a2b12d5-b30d-4e67-b31f-5fe19a367485") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("66d20726-5805-4468-86f2-63ae89d402c1"), new Guid("7ca69cfa-88fc-4569-aed2-a1becaf4f9a6") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a2b12d5-b30d-4e67-b31f-5fe19a367485"),
                column: "ConcurrencyStamp",
                value: "bbe5cbf7-418e-4c1e-9bea-9ceac7744826");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7ca69cfa-88fc-4569-aed2-a1becaf4f9a6"),
                column: "ConcurrencyStamp",
                value: "5a987266-d9e7-44d9-a713-2b5ce340ad33");
        }
    }
}
