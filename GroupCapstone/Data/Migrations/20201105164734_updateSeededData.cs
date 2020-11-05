using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Data.Migrations
{
    public partial class updateSeededData : Migration
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
                keyValue: "3ea30b19-dfb9-4b7c-b60a-3fd5f7e727a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a2d01e-244e-4ed4-a063-3e8a2ed980ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3e4729-af0b-4be2-8436-46ec93c616f1");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Order",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "302d25db-f92e-4b7e-8c3e-143f1e395eab", "2e801a79-0e40-4e27-af18-65c582df5237", "Admin", "ADMIN" },
                    { "3965988e-dd5a-4577-ac96-2b18fe678c8e", "82b2dad0-d6bf-454b-a057-d434b5807bd8", "Employee", "EMPLOYEE" },
                    { "4972a75a-24ef-4354-b296-836fbcb4bb71", "405884a4-f71c-4ec5-859e-ce8bab05a50b", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "FirstName", "IdentityUserId", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "customer1@consume.com", "Bob", null, "McBoberson", "414-555-1234" },
                    { 2, "customer1@consume.com", "Tom", null, "Tomson", "123-456-7890" },
                    { 3, "", "", null, "", "" },
                    { 4, "", "", null, "", "" },
                    { 5, "", "", null, "", "" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Details", "ImageUrl", "Name", "Price", "ProductCategory" },
                values: new object[,]
                {
                    { 1, "Wisconsin cheese from Mexico.", "", "Cheese", 2, "Dairy" },
                    { 2, "Harvested by blind monks.", "", "Coffee", 20, "Dry goods" },
                    { 3, "99% tofu the rest is a secrect.", "", "Vegan Sausages", 9, "Vegan" },
                    { 4, "No horses were harmed in the making of this product.", "", "Dog food", 5, "Pets" },
                    { 5, "Please do not drink this product", "", "Windex", 3, "Cleaners" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "Date", "IsCompleted", "IsPicked", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 50 },
                    { 3, 1, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 120 },
                    { 5, 1, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 80 },
                    { 2, 2, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 20 },
                    { 4, 2, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 70 },
                    { 6, 2, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0, 2, 5 },
                    { 2, 2, 0, 2, 1 },
                    { 3, 2, 0, 3, 8 },
                    { 4, 4, 0, 4, 18 },
                    { 5, 4, 0, 5, 14 },
                    { 6, 4, 0, 3, 2 }
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
                keyValue: "302d25db-f92e-4b7e-8c3e-143f1e395eab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3965988e-dd5a-4577-ac96-2b18fe678c8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4972a75a-24ef-4354-b296-836fbcb4bb71");

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44a2d01e-244e-4ed4-a063-3e8a2ed980ca", "7157b53c-1866-49c2-9ca1-a2d00761ee71", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ea30b19-dfb9-4b7c-b60a-3fd5f7e727a5", "8c794f0b-f62a-42d9-9c7f-1987c182e605", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea3e4729-af0b-4be2-8436-46ec93c616f1", "8d0f2355-4027-476c-9e38-ca8c96cef007", "Customer", "CUSTOMER" });

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
