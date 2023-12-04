using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleaningCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "_clientId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("31d51d70-ebdc-40a2-b85f-5db8747ea492"), null, "Client", "CLIENT" },
                    { new Guid("8e019027-0038-494a-9df8-0d20e7fd0f4e"), null, "Admin", "ADMIN" },
                    { new Guid("a12e815f-4af2-4062-ac76-3882c608d029"), null, "Worker", "WORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders__clientId",
                table: "Orders",
                column: "_clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers__clientId",
                table: "Orders",
                column: "_clientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers__clientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders__clientId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "_clientId",
                table: "Orders");
        }
    }
}
