using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleaningCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSomeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d188029-f747-4c9b-bdfe-7bdaaff3fb90"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3bae968-7137-4f2e-bf57-d971eae8735d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("efb71232-22c5-49fc-b0ea-356d1b135e1d"));

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmployeeWhoApprovedId",
                table: "OrderEmployees");

            migrationBuilder.DropColumn(
                name: "EmployeeWhoPerformedId",
                table: "OrderEmployees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3700b933-a3a8-427c-860c-135362bb6d1e"), null, "Worker", "WORKER" },
                    { new Guid("71115482-0b4e-4a13-851f-6320d294d5ba"), null, "Client", "CLIENT" },
                    { new Guid("c0198c53-2ae5-437e-9037-8dc389965905"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3700b933-a3a8-427c-860c-135362bb6d1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71115482-0b4e-4a13-851f-6320d294d5ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0198c53-2ae5-437e-9037-8dc389965905"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "PriceLists",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeWhoApprovedId",
                table: "OrderEmployees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeWhoPerformedId",
                table: "OrderEmployees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7d188029-f747-4c9b-bdfe-7bdaaff3fb90"), null, "Worker", "WORKER" },
                    { new Guid("e3bae968-7137-4f2e-bf57-d971eae8735d"), null, "Admin", "ADMIN" },
                    { new Guid("efb71232-22c5-49fc-b0ea-356d1b135e1d"), null, "Client", "CLIENT" }
                });
        }
    }
}
