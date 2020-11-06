using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Migrations
{
    public partial class _141 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "StoreInfo_1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    AddressZip = table.Column<int>(nullable: false),
                    StoreHours = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    CompanyVision = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInfo_1", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49de5f91-af3b-42d6-b44e-b846c996e1b2", "ee048427-5404-4857-af8e-f044739a9b4a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c78a6c7-8616-4125-bf9b-19438615a2ff", "951e1db6-c705-412b-9025-85abd2f1873e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f86458de-16cc-43b2-96ae-51f9a197c7de", "7c13580f-e4db-4c71-b8b4-92889e87f160", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreInfo_1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c78a6c7-8616-4125-bf9b-19438615a2ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49de5f91-af3b-42d6-b44e-b846c996e1b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f86458de-16cc-43b2-96ae-51f9a197c7de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff415e91-5764-40cb-b904-d546e8713e2a", "904dedb4-874b-4876-bc14-786b31fb8881", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe5e89de-62f9-46a5-a19f-bcbb9e57bfad", "561e0827-4178-49e4-b6e6-1e9d5417e87d", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a27ec716-95ea-45f6-8d3f-33a67126c762", "82237900-f44b-42e0-916d-714f8ca43b56", "Customer", "CUSTOMER" });
        }
    }
}
