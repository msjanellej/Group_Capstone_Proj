using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Migrations
{
    public partial class initial2234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65e094f2-b824-4129-8aaf-1c1b826b8b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbd49c5a-63e7-4671-adb0-abdcfee856b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d927a9cc-db29-436e-b149-8bcc006994f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec9c0d24-07da-427e-a173-0e6acf155810", "ae6e5266-9293-4865-89b5-360301413dd6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1d6f037-fceb-4aa1-b3f0-e7ef4946750c", "5d8eb159-0cfc-41ac-ac92-84b879ccc8b8", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "809b7ad9-c0cd-4a55-b9e4-c9a55e1d732c", "03b487c7-9b9a-4888-829d-ade3646d7eb0", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "809b7ad9-c0cd-4a55-b9e4-c9a55e1d732c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1d6f037-fceb-4aa1-b3f0-e7ef4946750c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec9c0d24-07da-427e-a173-0e6acf155810");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbd49c5a-63e7-4671-adb0-abdcfee856b1", "8c902006-0dbd-4464-a493-9662b736469b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d927a9cc-db29-436e-b149-8bcc006994f8", "c31e61a1-6edd-4834-be9d-d0579eb36852", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65e094f2-b824-4129-8aaf-1c1b826b8b63", "47a353b5-cf9d-4b2b-8321-8411d183f013", "Customer", "CUSTOMER" });
        }
    }
}
