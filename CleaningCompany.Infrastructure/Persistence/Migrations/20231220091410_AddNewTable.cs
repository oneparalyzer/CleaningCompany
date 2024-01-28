using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleaningCompany.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderOrderStatus",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderStatus", x => new { x.OrderId, x.StatusesId });
                    table.ForeignKey(
                        name: "FK_OrderOrderStatus_OrderStatuses_StatusesId",
                        column: x => x.StatusesId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderStatus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1727cf08-4dab-45af-bd05-9071e571421f"), null, "Admin", "ADMIN" },
                    { new Guid("683125fa-8c1d-42ee-97e3-01926e17b50e"), null, "Client", "CLIENT" },
                    { new Guid("ac8bd702-42d0-4526-9ec4-6969b198dab3"), null, "Worker", "WORKER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderStatus_StatusesId",
                table: "OrderOrderStatus",
                column: "StatusesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderStatus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1727cf08-4dab-45af-bd05-9071e571421f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("683125fa-8c1d-42ee-97e3-01926e17b50e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ac8bd702-42d0-4526-9ec4-6969b198dab3"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderStatusId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3700b933-a3a8-427c-860c-135362bb6d1e"), null, "Worker", "WORKER" },
                    { new Guid("71115482-0b4e-4a13-851f-6320d294d5ba"), null, "Client", "CLIENT" },
                    { new Guid("c0198c53-2ae5-437e-9037-8dc389965905"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
