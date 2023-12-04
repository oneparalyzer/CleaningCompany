using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleaningCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRelationals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("31d51d70-ebdc-40a2-b85f-5db8747ea492"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e019027-0038-494a-9df8-0d20e7fd0f4e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12e815f-4af2-4062-ac76-3882c608d029"));

            migrationBuilder.AddColumn<Guid>(
                name: "_employeeId",
                table: "PriceLists",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "_employeeWhoApprovedId",
                table: "OrderEmployees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "_employeeWhoPerformedId",
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

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists__employeeId",
                table: "PriceLists",
                column: "_employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEmployees__employeeWhoApprovedId",
                table: "OrderEmployees",
                column: "_employeeWhoApprovedId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEmployees__employeeWhoPerformedId",
                table: "OrderEmployees",
                column: "_employeeWhoPerformedId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployees_AspNetUsers__employeeWhoApprovedId",
                table: "OrderEmployees",
                column: "_employeeWhoApprovedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEmployees_AspNetUsers__employeeWhoPerformedId",
                table: "OrderEmployees",
                column: "_employeeWhoPerformedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_AspNetUsers__employeeId",
                table: "PriceLists",
                column: "_employeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployees_AspNetUsers__employeeWhoApprovedId",
                table: "OrderEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEmployees_AspNetUsers__employeeWhoPerformedId",
                table: "OrderEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_AspNetUsers__employeeId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists__employeeId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_OrderEmployees__employeeWhoApprovedId",
                table: "OrderEmployees");

            migrationBuilder.DropIndex(
                name: "IX_OrderEmployees__employeeWhoPerformedId",
                table: "OrderEmployees");

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
                name: "_employeeId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "_employeeWhoApprovedId",
                table: "OrderEmployees");

            migrationBuilder.DropColumn(
                name: "_employeeWhoPerformedId",
                table: "OrderEmployees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("31d51d70-ebdc-40a2-b85f-5db8747ea492"), null, "Client", "CLIENT" },
                    { new Guid("8e019027-0038-494a-9df8-0d20e7fd0f4e"), null, "Admin", "ADMIN" },
                    { new Guid("a12e815f-4af2-4062-ac76-3882c608d029"), null, "Worker", "WORKER" }
                });
        }
    }
}
