using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Migrations
{
    public partial class intial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff415e91-5764-40cb-b904-d546e8713e2a", "904dedb4-874b-4876-bc14-786b31fb8881", "Admin", "ADMIN" },
                    { "fe5e89de-62f9-46a5-a19f-bcbb9e57bfad", "561e0827-4178-49e4-b6e6-1e9d5417e87d", "Employee", "EMPLOYEE" },
                    { "a27ec716-95ea-45f6-8d3f-33a67126c762", "82237900-f44b-42e0-916d-714f8ca43b56", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Details", "ImageUrl", "Name", "Price", "ProductCategory" },
                values: new object[,]
                {
                    { 1, "Wisconsin cheese from Mexico.", "", "Cheese", 2.0, "Dairy" },
                    { 2, "Harvested by blind monks.", "", "Coffee", 20.0, "Dry goods" },
                    { 3, "99% tofu the rest is a secrect.", "", "Vegan Sausages", 9.0, "Vegan" },
                    { 4, "No horses were harmed in the making of this product.", "", "Dog food", 5.0, "Pets" },
                    { 5, "Please do not drink this product", "", "Windex", 3.0, "Cleaners" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0.0, 2, 5 },
                    { 2, 2, 0.0, 2, 1 },
                    { 3, 2, 0.0, 3, 8 },
                    { 6, 4, 0.0, 3, 2 },
                    { 4, 4, 0.0, 4, 18 },
                    { 5, 4, 0.0, 5, 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a27ec716-95ea-45f6-8d3f-33a67126c762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe5e89de-62f9-46a5-a19f-bcbb9e57bfad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff415e91-5764-40cb-b904-d546e8713e2a");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d64bca78-435d-4dad-9188-ee07277b62cd", "b686d665-90d4-45e2-8e66-2521a09dcdd5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58e43859-7edb-4a4c-9609-141e3fbb8e33", "3f1a61d3-1229-44dc-b04a-4d0a2adeb6bd", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e061616-4cd7-409b-ab41-245d4edd1594", "41bbf6d4-929f-49ab-8424-e0d3ff86a014", "Customer", "CUSTOMER" });
        }
    }
}
