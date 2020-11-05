using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Migrations
{
    public partial class intial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2527ab5f-d956-48f7-9f95-d657f71c6be9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c09aab66-6497-4035-bd84-3a4119366dff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a9ca13-2281-4d9c-a85e-fa847b83fefb");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Order",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d64bca78-435d-4dad-9188-ee07277b62cd", "b686d665-90d4-45e2-8e66-2521a09dcdd5", "Admin", "ADMIN" },
                    { "58e43859-7edb-4a4c-9609-141e3fbb8e33", "3f1a61d3-1229-44dc-b04a-4d0a2adeb6bd", "Employee", "EMPLOYEE" },
                    { "5e061616-4cd7-409b-ab41-245d4edd1594", "41bbf6d4-929f-49ab-8424-e0d3ff86a014", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "Date", "IsCompleted", "IsPicked", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 50 },
                    { 2, 2, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 20 },
                    { 3, 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 120 },
                    { 4, 2, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 70 },
                    { 5, 1, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 80 },
                    { 6, 2, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58e43859-7edb-4a4c-9609-141e3fbb8e33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e061616-4cd7-409b-ab41-245d4edd1594");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64bca78-435d-4dad-9188-ee07277b62cd");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5a9ca13-2281-4d9c-a85e-fa847b83fefb", "d97accc9-c4b6-4d4c-a790-4782e4c72048", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2527ab5f-d956-48f7-9f95-d657f71c6be9", "62fcc530-840d-4692-ad48-f67512ae3d91", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c09aab66-6497-4035-bd84-3a4119366dff", "3010d3bd-d172-434f-9eb4-3849865aa2a8", "Customer", "CUSTOMER" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
